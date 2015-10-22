using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEvaluationCoacheeRepository : IDisposable
    {
        EvaluationCoachee GetOne(Guid id);
        List<EvaluationCoachee> GetAll();
        List<EvaluationCoachee> GetAll(int take, int skip);
        List<EvaluationCoachee> GetAllBySession(Guid id);
        List<EvaluationCoachee> GetAllByCoachee(Guid id);
        List<EvaluationCoachee> GetAllByCoacheeAndSession(Guid idCoach, Guid idSession);
        void Create(EvaluationCoachee Evaluation);
        void Update(EvaluationCoachee Evaluation);
        void Delete(EvaluationCoachee Evaluation);
    }
}
