using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class UserInformation:Entity<Guid>
    {
        public Guid UserId { get; set; }
        public ICollection<Notification> Notifications{ get; set; }
        public User User { get; set; }

    }
}
