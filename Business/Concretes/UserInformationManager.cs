using AutoMapper;
using Business.Abstracts;
using Business.Dtos.UserInformation.Requests;
using Business.Dtos.UserInformation.Responses;
using Business.Dtos.UserInformation.Requests;
using Business.Dtos.UserInformation.Responses;
using Business.Rules;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserInformationManager : IUserInformationService
    {
        IUserInformationDal _userInformationDal;
        IMapper _mapper;
        UserInformationBusinessRules _businessRules;

        public UserInformationManager(IUserInformationDal userInformationDal, IMapper mapper, UserInformationBusinessRules businessRules)
        {
            _userInformationDal = userInformationDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetUserInformationResponse> Add(CreateUserInformationRequest request)
        {
            UserInformation UserInformation = _mapper.Map<UserInformation>(request);

            await _userInformationDal.AddAsync(UserInformation);
            GetUserInformationResponse response = _mapper.Map<GetUserInformationResponse>(request);
            return response;
        }

        public async Task<GetUserInformationResponse> Delete(DeleteUserInformationRequest request)
        {
            UserInformation UserInformation = await _userInformationDal.GetAsync(predicate: c => c.Id == request.Id);

            await _businessRules.UserInformationShouldExistWhenSelected(UserInformation);

            await _userInformationDal.DeleteAsync(UserInformation);
            GetUserInformationResponse response = _mapper.Map<GetUserInformationResponse>(UserInformation);
            return response;
        }

        public async Task<GetUserInformationResponse> Get(Guid id)
        {
            UserInformation UserInformation = await _userInformationDal.GetAsync(predicate: c => c.Id == id);
            await _businessRules.UserInformationShouldExistWhenSelected(UserInformation);
            GetUserInformationResponse response = _mapper.Map<GetUserInformationResponse>(UserInformation);
            return response;
        }

        public async Task<IPaginate<GetListUserInformationResponse>> GetList(PageRequest request)
        {
            var result = await _userInformationDal.GetListAsync(index: request.Index, size: request.Size);
            Paginate<GetListUserInformationResponse> response = _mapper.Map<Paginate<GetListUserInformationResponse>>(result);
            return response;
        }

        public async Task<GetUserInformationResponse> Update(UpdateUserInformationRequest request)
        {
            var result = await _userInformationDal.GetAsync(predicate: a => a.Id == request.Id);
            await _businessRules.UserInformationShouldExistWhenSelected(result);

            _mapper.Map(request, result);

            await _userInformationDal.UpdateAsync(result);
            GetUserInformationResponse response = _mapper.Map<GetUserInformationResponse>(result);
            return response;

        }
    }
}
