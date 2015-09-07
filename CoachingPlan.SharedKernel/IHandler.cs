using CoachingPlan.SharedKernel.Events.Contracts;
using System;
using System.Collections.Generic;

namespace CoachingPlan.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
