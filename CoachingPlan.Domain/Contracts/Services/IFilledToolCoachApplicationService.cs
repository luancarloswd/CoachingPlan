using CoachingPlan.Domain.Commands.FilledToolCoachCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IFilledToolCoachApplicationService : IDisposable
    {
        FilledToolCoach GetOne(Guid id);
        List<FilledToolCoach> GetAll();
        List<FilledToolCoach> GetAll(int take, int skip);
        FilledToolCoach Create(CreateFilledToolCoachCommand command);
        FilledToolCoach Update(UpdateFilledToolCoachCommand command);
        FilledToolCoach Delete(Guid id);
    }
}
