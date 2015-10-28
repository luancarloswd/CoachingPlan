using CoachingPlan.Domain.Commands.EvaluationToolCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEvaluationToolApplicationService : IDisposable
    {
        EvaluationTool GetOne(Guid id);
        List<EvaluationTool> GetAll();
        List<EvaluationTool> GetAllByCoach(Guid id);
        List<EvaluationTool> GetAllByCoachee(Guid id);
        List<EvaluationTool> GetAll(int take, int skip);
        EvaluationTool Create(CreateEvaluationToolCommand command);
        EvaluationTool Update(UpdateEvaluationToolCommand command);
        EvaluationTool Delete(Guid idEvaluationTool);
        List<EvaluationTool> GetAllIncludeDetails();
        EvaluationTool GetOneIncludeFilledTool(Guid id);
    }
}
