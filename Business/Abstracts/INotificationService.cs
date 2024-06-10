using Business.Dtos.Notification.Requests;
using Business.Dtos.Notification.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface INotificationService
    {
        Task<GetNotificationResponse> Add(CreateNotificationRequest createNotificationRequest);
        Task<GetNotificationResponse> Update(UpdateNotificationRequest updateNotificationRequest);
        Task<GetNotificationResponse> Delete(DeleteNotificationRequest deleteNotificationRequest);
        Task<IPaginate<GetListNotificationResponse>> GetList(PageRequest pageRequest);
        Task<IPaginate<GetListNotificationResponse>> GetListUserId(PageRequest pageRequest, Guid id);
        Task<GetNotificationResponse> Get(Guid id);
    }
}
