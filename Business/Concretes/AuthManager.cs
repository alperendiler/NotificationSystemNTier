using AutoMapper;
using Business.Abstract;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Business.Dtos.Users.Requests;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.Extensions.Configuration;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserService _userService;
            private ITokenHelper<Guid, int> _tokenHelper;
            private IMapper _mapper;
            IUserOperationClaimService _userOperationClaimService;
            private IRefreshTokenService _refreshTokenService;

        public AuthManager(IUserService userService, ITokenHelper<Guid, int> tokenHelper, IMapper mapper, IUserOperationClaimService userOperationClaimService, IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _userOperationClaimService = userOperationClaimService;
            _refreshTokenService = refreshTokenService;
        }

             [ValidationAspect(typeof(UserRequestValidator))]
            public async Task<User> Register(RegisterAuthRequest request, string password)
            {
                User user = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);

                var response = await _userService.Add(createUserRequest);

                return _mapper.Map<User>(response);



            }


            public async Task<User> Login(LoginAuthRequest request)
            {
                User user = _mapper.Map<User>(request);
                var loginUser = await _userService.GetByUserName(user.UserName);

            if (loginUser == null || !HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BusinessException(Messages.UserNameOrPasswordIncorrect);
            }

            var userResponse = _mapper.Map<User>(loginUser);

                return userResponse;
            }

            public Task UserExists(string userName)
            {
                var getByUserResult = _userService.GetByUserName(userName);
                if (getByUserResult.Result != null)
                {

                    throw new BusinessException(Messages.UserAlreadyExists);
                }
                return Task.CompletedTask;
            }
        public async Task<RegisteredResponse> HandleRegister(RegisterAuthRequest request)
        {
            await UserExists(request.UserName);

            var createdUser = await Register(request, request.Password);
            var createdAccessToken = await CreateAccessToken(createdUser);
            var createdRefreshToken = await CreateRefreshToken(createdUser, request.IpAddress);
            var addedRefreshToken = await AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = _mapper.Map<Entities.Concretes.RefreshToken>(addedRefreshToken) 
            };

            return registeredResponse;
        }
        public async Task<AccessToken> CreateAccessToken(User user)
        {
         

            IList<OperationClaim> operationClaims = await _userOperationClaimService.GetOperationClaimsByUserIdAsync(user.Id);
            Core.Utilities.Security.Jwt.AccessToken accessToken = _tokenHelper.CreateToken(
                user,
                operationClaims.Select(op => (OperationClaim<int>)op).ToImmutableList()
            );
            return accessToken;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken<Guid> coreRefreshToken = _tokenHelper.CreateRefreshToken(
            user,
            ipAddress
        );
            RefreshToken refreshToken = _mapper.Map<RefreshToken>(coreRefreshToken);
            return Task.FromResult(refreshToken);
        }

   public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
{
    RefreshToken addedRefreshToken = await _refreshTokenService.AddAsync(refreshToken);
    return addedRefreshToken;
}
      
    }
    }
    