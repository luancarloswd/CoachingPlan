using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEvaluationCoachRepository : IDisposable
    {
        EvaluationCoach GetOne(Guid id);
        List<EvaluationCoach> GetAll();
        List<EvaluationCoach> GetAll(int take, int skip);
        List<EvaluationCoach> GetAllBySession(Guid id);
        List<EvaluationCoach> GetAllByCoach(Guid id);
        List<EvaluationCoach> GetAllByCoachAndSession(Guid idCoach, Guid idSession);
        void Create(EvaluationCoach Evaluation);
        void Update(EvaluationCoach Evaluation);
        void Delete(EvaluationCoach Evaluation);
    }
}
