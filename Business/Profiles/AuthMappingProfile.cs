using AutoMapper;
using Business.Dtos.Auth.Responses;
using Business.Dtos.Notification.Requests;
using Business.Dtos.Notification.Responses;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            
            CreateMap<RefreshToken<Guid>, RefreshToken>().ReverseMap();

            CreateMap<RefreshToken, RegisteredResponse>()
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.Token)) 
                .ReverseMap();

            CreateMap<AccessToken, RegisteredResponse>()
                .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.Token)) 
                .ReverseMap();
        }
    }
}
