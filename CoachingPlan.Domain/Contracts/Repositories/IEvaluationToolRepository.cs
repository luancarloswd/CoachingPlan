using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace EvaluationToolingPlan.Domain.Contracts.Repositories
{
    public interface IEvaluationToolRepository : IDisposable
    {
        EvaluationTool GetOne(Guid id);
        List<EvaluationTool> GetAll();
        List<EvaluationTool> GetAll(int take, int skip);
        void Create(EvaluationTool EvaluationTool);
        void Update(EvaluationTool EvaluationTool);
        void Delete(EvaluationTool EvaluationTool);
    }
}
