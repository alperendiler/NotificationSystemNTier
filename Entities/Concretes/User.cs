using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class User :User<Guid>
    {
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
        public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    }
}
