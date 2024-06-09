using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserInformation.Requests
{
    public class UpdateUserInformationRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
