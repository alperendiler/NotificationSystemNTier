using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Core.Utilities.Security.Jwt;
using Entities.Concretes;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<User> Register(RegisterAuthRequest registerAuthRequest, string password);
        Task<User> Login(LoginAuthRequest loginAuthRequest);
        Task UserExists(string email);
        Task<AccessToken> CreateAccessToken(User user);

    }
}