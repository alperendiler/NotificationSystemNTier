using Business.Constants;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserInformationBusinessRules : BaseBusinessRules
    {
        IUserInformationDal _UserInformationDal;

        public UserInformationBusinessRules(IUserInformationDal UserInformationDal)
        {
            _UserInformationDal = UserInformationDal;
        }
        public Task UserInformationShouldExistWhenSelected(UserInformation? UserInformation)
        {
            if (UserInformation == null)
                throw new BusinessException(Messages.UserInformationNotExists);
            return Task.CompletedTask;
        }

        public async Task UserInformationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
        {
            UserInformation? UserInformation = await _UserInformationDal.GetAsync(
                predicate: a => a.Id == id,
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            await UserInformationShouldExistWhenSelected(UserInformation);
        }
    }
}
