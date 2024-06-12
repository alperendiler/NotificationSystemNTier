using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper<TUserId, TOperationClaimId>
    {
        AccessToken CreateToken(User<TUserId> user, IList<OperationClaim<TOperationClaimId>> operationClaims);

        RefreshToken<TUserId> CreateRefreshToken(User<TUserId> user, string ipAddress);
    }
}
