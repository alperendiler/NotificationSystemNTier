﻿using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserDal : IRepository<User, Guid>, IAsyncRepository<User, Guid>
    {
        Task<List<OperationClaim>> GetClaims(User user);

    }
}
