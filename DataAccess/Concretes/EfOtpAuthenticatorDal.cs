﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfOtpAuthenticatorDal : EfRepositoryBase<OtpAuthenticator, Guid, NotificationSystemContext>, IOtpAuthenticatorDal
    {
        public EfOtpAuthenticatorDal(NotificationSystemContext context) : base(context)
        {
        }
    }
}
