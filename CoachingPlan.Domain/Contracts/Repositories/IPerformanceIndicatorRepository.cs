using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace PerformanceIndicatoringPlan.Domain.Contracts.Repositories
{
    public interface IPerformanceIndicatorRepository : IDisposable
    {
        PerformanceIndicator GetOne(Guid id);
        List<PerformanceIndicator> GetAll();
        List<PerformanceIndicator> GetAll(int take, int skip);
        void Create(PerformanceIndicator PerformanceIndicator);
        void Update(PerformanceIndicator PerformanceIndicator);
        void Delete(PerformanceIndicator PerformanceIndicator);
    }
}
