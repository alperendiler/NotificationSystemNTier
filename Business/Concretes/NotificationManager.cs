using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Notification.Requests;
using Business.Dtos.Notification.Responses;
using Business.Rules;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class NotificationManager : INotificationService
    {

        INotificationDal _notificationDal;
        IMapper _mapper;
        NotificationBusinessRules _businessRules;

        public NotificationManager(INotificationDal notificationDal, IMapper mapper, NotificationBusinessRules businessRules)
        {
            _notificationDal = notificationDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }
        public async Task<GetNotificationResponse> Add(CreateNotificationRequest request)
        {
            Notification notification = _mapper.Map<Notification>(request);

            await _notificationDal.AddAsync(notification);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(request);
            return response;
        }

        public async Task<GetNotificationResponse> Delete(DeleteNotificationRequest request)
        {
            Notification Notification = await _notificationDal.GetAsync(predicate: c => c.Id == request.Id);

            await _businessRules.NotificationShouldExistWhenSelected(Notification);

            await _notificationDal.DeleteAsync(Notification);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(Notification);
            return response;
        }

        public async Task<GetNotificationResponse> Get(Guid id)
        {
            Notification Notification = await _notificationDal.GetAsync(predicate: c => c.Id == id);
            await _businessRules.NotificationShouldExistWhenSelected(Notification);
            GetNotificationResponse response = _mapper.Map<GetNotificationResponse>(Notification);
            return response;
        }

        public async Task<IPaginate<GetListNotificationResponse>> GetList(PageRequest request)
        {
            var result = await _notificationDal.GetListAsync(index: request.Index, size: request.Size);
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
            return response;

        }
    }
}
