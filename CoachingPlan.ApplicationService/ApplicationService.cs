using CoachingPlan.Infraestructure.Data;
using CoachingPlan.SharedKernel;
using CoachingPlan.SharedKernel.Events;
using System.Collections.Generic;

namespace CoachingPlan.ApplicationService
{
    public class BaseApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public BaseApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
