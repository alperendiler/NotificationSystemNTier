using Business.Dtos.Users.Requests;
using Business.Dtos.Users.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserOperationClaimService
    {
        Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(Guid userId);

    }
    
}
