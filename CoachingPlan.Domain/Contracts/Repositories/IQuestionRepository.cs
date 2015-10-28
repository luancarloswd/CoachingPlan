using CoachingPlan.Domain.Commands.QuestionCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IQuestionRepository : IDisposable
    {
        Question GetOne(Guid id);
        List<Question> GetAll();
        List<Question> GetAllByEvaluationTool(Guid idEvaluationTool);
        List<Question> GetAll(int take, int skip);
        void Create(Question question);
        void Update(Question question);
        void Delete(Question question);
    }
}
