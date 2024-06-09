using AutoMapper;
using Business.Dtos.Notification.Requests;
using Business.Dtos.Notification.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Profiles
{
    internal class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, CreateNotificationRequest>().ReverseMap();
            CreateMap<Notification, DeleteNotificationRequest>().ReverseMap();
            CreateMap<Notification, UpdateNotificationRequest>().ReverseMap();
            CreateMap<GetNotificationResponse, CreateNotificationRequest>().ReverseMap();
            CreateMap<GetNotificationResponse, DeleteNotificationRequest>().ReverseMap();
            CreateMap<GetNotificationResponse, UpdateNotificationRequest>().ReverseMap();

            CreateMap<Notification, GetNotificationResponse>().ReverseMap();
            CreateMap<Notification, GetListNotificationResponse>().ReverseMap();

            CreateMap<Paginate<Notification>, Paginate<GetListNotificationResponse>>().ReverseMap();
        }
    }
}
