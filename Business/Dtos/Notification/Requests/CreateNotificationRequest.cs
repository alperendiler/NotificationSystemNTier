using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Notification.Requests
{
    public class CreateNotificationRequest
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
    }
}
