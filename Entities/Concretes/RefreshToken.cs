using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class RefreshToken : RefreshToken<Guid>
    {
        public virtual User User { get; set; } = default!;
    }
}
