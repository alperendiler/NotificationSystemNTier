using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfUserOperationClaimDal : EfRepositoryBase<UserOperationClaim, Guid, NotificationSystemContext>, IUserOperationClaimDal
    {
        public EfUserOperationClaimDal(NotificationSystemContext context)
            : base(context) { }

        public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(Guid userId)
        {
            return await Query()
                .Include(p => p.OperationClaim)
                .Where(p => p.UserId == userId)
                .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
                .ToListAsync();
        }
    }
}
