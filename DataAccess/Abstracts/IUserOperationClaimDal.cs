using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IUserOperationClaimDal : IAsyncRepository<UserOperationClaim, Guid>, IRepository<UserOperationClaim, Guid>
    {
        Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(Guid userId);

    }
}
