using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        AppDataContext _context;
        public QuestionRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Question Question)
        {
            _context.Question.Add(Question);
        }

        public void Delete(Question Question)
        {
            _context.Question.Remove(Question);
        }

        public List<Question> GetAll()
        {
            return _context.Question.ToList();
        }
        public List<Question> GetAllByEvaluationTool(Guid id)
        {
            return _context.Question.Where(QuestionSpecs.GetAllByEvaluationTool(id)).ToList();
        }

        public List<Question> GetAll(int take, int skip)
        {
            return _context.Question.OrderBy(x => x.Enunciation).Skip(skip).Take(take).ToList();
        }

        public Question GetOne(Guid id)
        {
            return _context.Question.Where(QuestionSpecs.GetOne(id)).Include(x => x.Reply).FirstOrDefault();
        }

        public void Update(Question Question)
        {
            _context.Entry<Question>(Question).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
