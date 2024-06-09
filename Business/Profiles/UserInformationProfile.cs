using AutoMapper;
using Business.Dtos.UserInformation.Requests;
using Business.Dtos.UserInformation.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserInformationProfile : Profile
    {
        public UserInformationProfile()
        {
            CreateMap<UserInformation, CreateUserInformationRequest>().ReverseMap();
            CreateMap<UserInformation, DeleteUserInformationRequest>().ReverseMap();
            CreateMap<UserInformation, UpdateUserInformationRequest>().ReverseMap();
            CreateMap<GetUserInformationResponse, CreateUserInformationRequest>().ReverseMap();
            CreateMap<GetUserInformationResponse, DeleteUserInformationRequest>().ReverseMap();
            CreateMap<GetUserInformationResponse, UpdateUserInformationRequest>().ReverseMap();

            CreateMap<UserInformation, GetUserInformationResponse>().ReverseMap();
            CreateMap<UserInformation, GetListUserInformationResponse>().ReverseMap();

            CreateMap<Paginate<UserInformation>, Paginate<GetListUserInformationResponse>>().ReverseMap();
        }
    }
}
