using Business.Dtos.UserInformation.Requests;
using Business.Dtos.UserInformation.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserInformationService
    {
        Task<GetUserInformationResponse> Add(CreateUserInformationRequest createUserInformationRequest);
        Task<GetUserInformationResponse> Update(UpdateUserInformationRequest updateUserInformationRequest);
        Task<GetUserInformationResponse> Delete(DeleteUserInformationRequest deleteUserInformationRequest);
        Task<IPaginate<GetListUserInformationResponse>> GetList(PageRequest pageRequest);
        Task<GetUserInformationResponse> Get(Guid id);
    }
}
