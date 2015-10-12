using CoachingPlan.Domain.Commands.PerformanceIndicatorCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IPerformanceIndicatorApplicationService : IDisposable
    {
        PerformanceIndicator GetOne(Guid id);
        List<PerformanceIndicator> GetAll();
        List<PerformanceIndicator> GetAll(int take, int skip);
        PerformanceIndicator Create(CreatePerformanceIndicatorCommand command);
        PerformanceIndicator Update(UpdatePerformanceIndicatorCommand command);
        PerformanceIndicator Delete(Guid idPerformanceIndicator);
        List<PerformanceIndicator> GetAllByCoachingProcess(Guid idCoachingProcess);
        List<PerformanceIndicator> AddToCoachingProcess(dynamic body);
        void CheckPerformanceIndicatorRemoved(List<PerformanceIndicator> listPerformanceIndicator, Guid idCoachingProcess);
    }
}
