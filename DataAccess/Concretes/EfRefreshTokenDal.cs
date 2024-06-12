using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfRefreshTokenDal : EfRepositoryBase<RefreshToken, Guid, NotificationSystemContext>, IRefreshTokenDal
    {
        public EfRefreshTokenDal(NotificationSystemContext context) : base(context)
        {
        }
        public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(Guid userId, int refreshTokenTtl)
        {
            List<RefreshToken> tokens = await Query()
                .AsNoTracking()
                .Where(r =>
                    r.UserId == userId
                    && r.RevokedDate == null
                    && r.ExpiresDate >= DateTime.UtcNow
                    && r.CreatedDate.AddDays(refreshTokenTtl) <= DateTime.UtcNow
                )
                .ToListAsync();

            return tokens;
        }
    }
}
