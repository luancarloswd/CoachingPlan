using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace QuestioningPlan.Domain.Contracts.Repositories
{
    public interface IQuestionRepository : IDisposable
    {
        Question GetOne(Guid id);
        List<Question> GetAll();
        List<Question> GetAll(int take, int skip);
        void Create(Question Question);
        void Update(Question Question);
        void Delete(Question Question);
    }
}
