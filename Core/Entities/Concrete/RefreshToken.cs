using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class RefreshToken<TUserId> : Entity<TUserId>
    {
        public TUserId UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiresDate { get; set; }

        public string CreatedByIp { get; set; }

        public DateTime? RevokedDate { get; set; }

        public string? RevokedByIp { get; set; }

        public string? ReplacedByToken { get; set; }

        public string? ReasonRevoked { get; set; }

        public RefreshToken()
        {
            UserId = default(TUserId);
            Token = string.Empty;
            CreatedByIp = string.Empty;
        }

        public RefreshToken(TUserId userId, string token, DateTime expiresDate, string createdByIp)
        {
            UserId = userId;
            Token = token;
            ExpiresDate = expiresDate;
            CreatedByIp = createdByIp;
        }

        public RefreshToken(TUserId id, TUserId userId, string token, DateTime expiresDate, string createdByIp)
            : base(id)
        {
            UserId = userId;
            Token = token;
            ExpiresDate = expiresDate;
            CreatedByIp = createdByIp;
        }
    }
    }
