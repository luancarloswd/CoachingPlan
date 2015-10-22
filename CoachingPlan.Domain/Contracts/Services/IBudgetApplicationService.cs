using CoachingPlan.Domain.Commands.BudgetCommands;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IBudgetApplicationService : IDisposable
    {
        Budget GetOne(Guid id);
        List<Budget> GetAll();
        List<Budget> GetAll(int take, int skip);
        Budget Create(CreateBudgetCommand command);
        Budget Update(UpdateBudgetCommand command);
        Budget Delete(Guid idService);
        List<Budget> GetAllByCoachingProcess(Guid idCoachingProcess);
    }
}
