using CoachingPlan.Domain.Commands.EvaluationCoachCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEvaluationCoachApplicationService : IDisposable
    {
        EvaluationCoach GetOne(Guid id);
        List<EvaluationCoach> GetAllBySession(Guid idSession);
        List<EvaluationCoach> GetAllByCoach(Guid idCoach);
        List<EvaluationCoach> GetAllByCoachAndSession(Guid idCoach, Guid idSession);
        List<EvaluationCoach> GetAll();
        List<EvaluationCoach> GetAll(int take, int skip);
        EvaluationCoach Create(CreateEvaluationCoachCommand Evaluation);
        EvaluationCoach Update(UpdateEvaluationCoachCommand Evaluation);
        EvaluationCoach Delete(Guid id);
        void CheckEvaluationCoachRemoved(List<EvaluationCoach> body, Guid idSession);
        List<EvaluationCoach> AddToSession(dynamic body, Guid idSession);

    }
}
