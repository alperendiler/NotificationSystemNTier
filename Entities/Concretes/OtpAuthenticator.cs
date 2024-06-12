using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class OtpAuthenticator : OtpAuthenticator<Guid>
    {
        public virtual User User { get; set; } = default!;
    }
}
