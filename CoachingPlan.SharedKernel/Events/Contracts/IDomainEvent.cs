using System;

namespace CoachingPlan.SharedKernel.Events.Contracts
{
    public interface IDomainEvent 
    {
        DateTime DateOccurred { get; }
    }
}
