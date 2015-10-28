using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEvaluationToolRepository : IDisposable
    {
        EvaluationTool GetOne(Guid id);
        List<EvaluationTool> GetAll();
        List<EvaluationTool> GetAllByCoach(Guid id);
        List<EvaluationTool> GetAllByCoachee(Guid id);
        List<EvaluationTool> GetAll(int take, int skip);
        List<EvaluationTool> GetAllIncludeDetails();
        void Create(EvaluationTool EvaluationTool);
        void Update(EvaluationTool EvaluationTool);
        void Delete(EvaluationTool EvaluationTool);
        EvaluationTool GetOneIncludeFilledTool(Guid id);
    }
}
