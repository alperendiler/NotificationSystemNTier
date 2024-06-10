using Business.Constants;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class NotificationBusinessRules : BaseBusinessRules
    {
        INotificationDal _NotificationDal;
        IUserDal _UserDal;
        public NotificationBusinessRules(INotificationDal notificationDal, IUserDal userDal)
        {
            _NotificationDal = notificationDal;
            _UserDal = userDal;
        }
        public Task NotificationShouldExistWhenSelected(Notification? notification)
        {
            if (notification == null)
                throw new BusinessException(Messages.NotificationNotExists);
            return Task.CompletedTask;
        }

        public async Task NotificationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
        {
            Notification? Notification = await _NotificationDal.GetAsync(
                predicate: a => a.Id == id,
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            await NotificationShouldExistWhenSelected(Notification);
        }
    
    }
}
