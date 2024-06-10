using Business.Abstract;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        IAuthService _authService;
        IUserDal _userDal;

        public AuthBusinessRules(IAuthService authService, IUserDal _userDal)
        {
            _authService = authService;
            _userDal = _userDal;
        }



    }
}
