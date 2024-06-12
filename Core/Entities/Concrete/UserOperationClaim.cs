using System.Security.Cryptography;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim<TUserId, TOperationClaimId> : Entity<TUserId>
    {
        public TUserId UserId { get; set; }

        public TOperationClaimId OperationClaimId { get; set; }

        public UserOperationClaim()
        {
            UserId = default(TUserId);
            OperationClaimId = default(TOperationClaimId);
        }

        public UserOperationClaim(TUserId userId, TOperationClaimId operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public UserOperationClaim(TUserId id, TUserId userId, TOperationClaimId operationClaimId)
            : base(id)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}
