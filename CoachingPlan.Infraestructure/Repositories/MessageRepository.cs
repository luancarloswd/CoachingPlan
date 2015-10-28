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
    public class MessageRepository : IMessageRepository
    {
        AppDataContext _context;
        public MessageRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Message message)
        {
            _context.Message.Add(message);
        }

        public void Delete(Message message)
        {
            _context.Message.Remove(message);
        }

        public List<Message> GetAll()
        {
            return _context.Message.ToList();
        }

        public List<Message> GetAll(int take, int skip)
        {
            return _context.Message.OrderBy(x => x.Date).Skip(skip).Take(take).ToList();
        }

        public Message GetOne(Guid id)
        {
            return _context.Message.Where(MessageSpecs.GetOne(id)).FirstOrDefault();
        }
        public List<Message> GetHistoryMessages(string idUser, string desdination)
        {
            return _context.Message.Where(MessageSpecs.GetHistory(idUser, desdination)).ToList();
        }
        public void Update(Message Message)
        {
            _context.Entry<Message>(Message).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
