﻿using Business.Dtos.Users.Requests;
using Business.Dtos.Users.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<GetUserResponse> Add(CreateUserRequest createUserRequest);
        Task<GetUserResponse> Update(UpdateUserRequest updateUserRequest);
        Task<GetUserResponse> Delete(DeleteUserRequest deleteUserRequest);
        Task<IPaginate<GetListUserResponse>> GetList(PageRequest pageRequest);
        Task<GetUserResponse> Get(Guid id);
        Task<GetUserResponse> GetByMail(string email);
        Task<GetUserResponse> GetByUserName(string userName);
        Task<List<OperationClaim>> GetClaims(User user);

    }
}
