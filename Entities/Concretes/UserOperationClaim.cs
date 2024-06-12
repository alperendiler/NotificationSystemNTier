using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class UserOperationClaim : UserOperationClaim<Guid, int>
    {
        public virtual User User { get; set; } = default!;
        public virtual OperationClaim OperationClaim { get; set; } = default!;
    }
}
