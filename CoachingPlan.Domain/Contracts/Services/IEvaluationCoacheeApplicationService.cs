using CoachingPlan.Domain.Commands.EvaluationCoacheeCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEvaluationCoacheeApplicationService : IDisposable
    {
        EvaluationCoachee GetOne(Guid id);
        List<EvaluationCoachee> GetAllBySession(Guid idSession);
        List<EvaluationCoachee> GetAllByCoachee(Guid idCoachee);
        List<EvaluationCoachee> GetAllByCoacheeAndSession(Guid idCoachee, Guid idSession);
        List<EvaluationCoachee> GetAll();
        List<EvaluationCoachee> GetAll(int take, int skip);
        EvaluationCoachee Create(CreateEvaluationCoacheeCommand Evaluation);
        EvaluationCoachee Update(UpdateEvaluationCoacheeCommand Evaluation);
        EvaluationCoachee Delete(Guid id);
        void CheckEvaluationCoacheeRemoved(List<EvaluationCoachee> body, Guid idSession);
        List<EvaluationCoachee> AddToSession(dynamic body, Guid idSession);

    }
}
