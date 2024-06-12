using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper<TUserId, TOperationClaimId> : ITokenHelper<TUserId, TOperationClaimId>
    {
        private readonly TokenOptions _tokenOptions;

        public JwtHelper(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions ?? throw new ArgumentNullException(nameof(tokenOptions));
        }

        public virtual AccessToken CreateToken(User<TUserId> user, IList<OperationClaim<TOperationClaimId>> operationClaims)
        {
            DateTime accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(
                _tokenOptions,
                user,
                signingCredentials,
                operationClaims,
                accessTokenExpiration
            );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string? token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken() { Token = token, ExpirationDate = accessTokenExpiration };
        }


        public RefreshToken< TUserId> CreateRefreshToken(User<TUserId> user, string ipAddress)
        {
            return new RefreshToken< TUserId>()
            {
                UserId = user.Id,
                Token = randomRefreshToken(),
                ExpiresDate = DateTime.UtcNow.AddDays(_tokenOptions.RefreshTokenTTL),
                CreatedByIp = ipAddress
            };
        }

        public virtual JwtSecurityToken CreateJwtSecurityToken(
            TokenOptions tokenOptions,
            User<TUserId> user,
            SigningCredentials signingCredentials,
            IList<OperationClaim<TOperationClaimId>> operationClaims,
            DateTime accessTokenExpiration
        )
        {
            return new JwtSecurityToken(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
        }

        protected virtual IEnumerable<Claim> SetClaims(User<TUserId> user, IList<OperationClaim<TOperationClaimId>> operationClaims)
        {
            List<Claim> claims = [];
            claims.AddNameIdentifier(user!.Id!.ToString()!);
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims.ToImmutableList();
        }

        private string randomRefreshToken()
        {
            byte[] numberByte = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}