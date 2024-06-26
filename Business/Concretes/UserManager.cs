﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Users.Requests;
using Business.Dtos.Users.Responses;
using Business.Rules;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _businessRules;

        public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules businessRules)
        {
            _userDal = userDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }



        public async Task<GetUserResponse> Add(CreateUserRequest request)
        {
            User user = _mapper.Map<User>(request);


            await _userDal.AddAsync(user);
            GetUserResponse response = _mapper.Map<GetUserResponse>(user);
            return response;

        }


        public async Task<GetUserResponse> Delete(DeleteUserRequest request)
        {
            User user = await _userDal.GetAsync(predicate: u => u.Id == request.Id);

            await _businessRules.UserShouldBeExistsWhenSelected(user);

            await _userDal.DeleteAsync(user);
            GetUserResponse response = _mapper.Map<GetUserResponse>(user);
            return response;

        }

        public async Task<GetUserResponse> Get(Guid id)
        {
            User user = await _userDal.GetAsync(predicate: u => u.Id == id);

            await _businessRules.UserShouldBeExistsWhenSelected(user);

            GetUserResponse response = _mapper.Map<GetUserResponse>(user);

            return response;
        }

        public async Task<GetUserResponse> GetByMail(string email)
        {
            var gettedUser = await _userDal.GetAsync(u => u.Email == email);
            GetUserResponse response = _mapper.Map<GetUserResponse>(gettedUser);
            return response;
        }

        public async Task<GetUserResponse> GetByUserName(string userName)
        {
            var gettedUser = await _userDal.GetAsync(u => u.UserName == userName);
            GetUserResponse response = _mapper.Map<GetUserResponse>(gettedUser);
            return response;
        }


        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _userDal.GetClaims(user);
        }

        public async Task<IPaginate<GetListUserResponse>> GetList(PageRequest request)
        {
            var result = await _userDal.GetListAsync(index: request.Index, size: request.Size);
            Paginate<GetListUserResponse> response = _mapper.Map<Paginate<GetListUserResponse>>(result);
            return response;
        }

        public async Task<GetUserResponse> Update(UpdateUserRequest request)
        {
            User user = await _userDal.GetAsync(predicate: c => c.Id == request.Id);

            await _businessRules.UserShouldBeExistsWhenSelected(user);

            User updatedUser = _mapper.Map(request, user);

            await _userDal.UpdateAsync(updatedUser);

            GetUserResponse response = _mapper.Map<GetUserResponse>(updatedUser);
            return response;
        }
    }
        
    }