using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class PerformanceIndicatorSpecs
    {
        public static Expression<Func<PerformanceIndicator, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<PerformanceIndicator, bool>> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return x => x.IdCoachingProcess == idCoachingProcess;
        }
    }
}
