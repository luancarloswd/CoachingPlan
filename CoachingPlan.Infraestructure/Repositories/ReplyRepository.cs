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
    public class ReplyRepository : IReplyRepository
    {
        AppDataContext _context;
        public ReplyRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Reply Reply)
        {
            _context.Reply.Add(Reply);
        }

        public void Delete(Reply Reply)
        {
            _context.Reply.Remove(Reply);
        }

        public List<Reply> GetAll()
        {
            return _context.Reply.ToList();
        }
        public List<Reply> GetAllByQuestion(Guid id)
        {
            return _context.Reply.Where(ReplySpecs.GetAllByQuestion(id)).ToList();
        }

        public List<Reply> GetAllByQuestionAndStatusOfTrue(Guid id)
        {
            return _context.Reply.Where(ReplySpecs.GetAllByQuestionAndStatusOfTrue(id)).ToList();
        }

        public List<Reply> GetAll(int take, int skip)
        {
            return _context.Reply.OrderBy(x => x.BodyReply).Skip(skip).Take(take).ToList();
        }

        public Reply GetOne(Guid id)
        {
            return _context.Reply.Where(ReplySpecs.GetOne(id)).FirstOrDefault();
        }

        public void Update(Reply Reply)
        {
            _context.Entry<Reply>(Reply).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
