using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Notification.Requests;
using Business.Dtos.Notification.Responses;
using Business.Rules;
using Core.Business.Requests;
using Core.CrossCuttingConcerns.SingalR;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        private readonly IMapper _mapper;
        private readonly NotificationBusinessRules _businessRules;
        private readonly IHubContext<SıngalRHub<GetNotificationResponse>> _hubContext;

        public NotificationManager(INotificationDal notificationDal, IMapper mapper, NotificationBusinessRules businessRules, IHubContext<SıngalRHub<GetNotificationResponse>> hubContext)
        {
            _notificationDal = notificationDal;
            _mapper = mapper;
            _businessRules = businessRules;
            _hubContext = hubContext;
        }

        public async Task<GetNotificationResponse> Add(CreateNotificationRequest request)
        {
            Notification notification = _mapper.Map<Notification>(request);

            await _notificationDal.AddAsync(notification);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(notification);

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", response);

            return response;
        }

        public async Task<GetNotificationResponse> Delete(DeleteNotificationRequest request)
        {
            Notification notification = await _notificationDal.GetAsync(predicate: c => c.Id == request.Id);

            await _businessRules.NotificationShouldExistWhenSelected(notification);

            await _notificationDal.DeleteAsync(notification);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(notification);

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", response);

            return response;
        }

        public async Task<GetNotificationResponse> Get(Guid id)
        {
            Notification notification = await _notificationDal.GetAsync(predicate: c => c.Id == id);
            await _businessRules.NotificationShouldExistWhenSelected(notification);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(notification);
            return response;
        }

        public async Task<IPaginate<GetListNotificationResponse>> GetList(PageRequest request)
        {
            var result = await _notificationDal.GetListAsync(index: request.Index, size: request.Size);
            Paginate<GetListNotificationResponse> response = _mapper.Map<Paginate<GetListNotificationResponse>>(result);
            return response;
        }

        public async Task<IPaginate<GetListNotificationResponse>> GetListUserId(PageRequest pageRequest, Guid id)
        {
            var result = await _notificationDal.GetListAsync(
                 index: pageRequest.Index,
                 size: pageRequest.Size,
                 predicate: a => a.UserId == id
                 );
            Paginate<GetListNotificationResponse> response = _mapper.Map<Paginate<GetListNotificationResponse>>(result);
            return response;
        }

        public async Task<GetNotificationResponse> Update(UpdateNotificationRequest request)
        {
            var result = await _notificationDal.GetAsync(predicate: a => a.Id == request.Id);
            await _businessRules.NotificationShouldExistWhenSelected(result);

            _mapper.Map(request, result);

            await _notificationDal.UpdateAsync(result);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(result);

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", response);

            return response;
        }
    }
}
