using CoachingPlan.Domain.Commands.StrongPointCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IStrongPointApplicationService : IDisposable
    {
        StrongPoint GetOne(Guid id);
        StrongPoint GetOnebyCoachee(Guid idCoachee);
        List<StrongPoint> GetAll();
        List<StrongPoint> GetAll(int take, int skip);
        StrongPoint Create(CreateStrongPointCommand StrongPoint);
        StrongPoint Update(ChangeStrongPointCommand StrongPoint);
        StrongPoint Delete(Guid id);
        List<StrongPoint> AddToCoachee(dynamic body);
    }
}
