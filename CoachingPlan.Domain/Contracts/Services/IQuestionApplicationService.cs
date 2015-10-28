using CoachingPlan.Domain.Commands.QuestionCommands;
using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IQuestionApplicationService : IDisposable
    {
        Question GetOne(Guid id);
        List<Question> GetAll();
        List<Question> GetAllByEvaluationTool(Guid idEvaluationTool);
        List<Question> GetAll(int take, int skip);
        Question Create(CreateQuestionCommand command);
        Question Update(UpdateQuestionCommand command);
        Question Delete(Guid idQuestion);
        List<Question> AddToEvaluationTool(dynamic body, ETypeEvaluationTool type);
        void CheckQuestionRemoved(List<Question> listQuestion, Guid idEvaluationTool);
    }
}
