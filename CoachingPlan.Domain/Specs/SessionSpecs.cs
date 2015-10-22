using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class SessionSpecs
    {
        public static Expression<Func<Session, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Session, bool>> GetAllByTypeSession(ESessionClassification classification)
        {
            return x => x.Classification == classification;
        }
        public static Expression<Func<Session, bool>> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return x => x.IdCoachingProcess == idCoachingProcess;
        }
    }
}
