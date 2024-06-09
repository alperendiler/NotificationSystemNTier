using Business.Constants;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class NotificationBusinessRules : BaseBusinessRules
    {
        INotificationDal _NotificationDal;

        public NotificationBusinessRules(INotificationDal notificationDal)
        {
            _NotificationDal = notificationDal;
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
