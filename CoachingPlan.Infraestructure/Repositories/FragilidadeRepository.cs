using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class FragilidadeRepository : IFragilidadeRepository
    {
        private AppDataContext _context;

        public FragilidadeRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Weakness GetOne(Guid id)
        {
            return _context.Fragilidade.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Weakness> GetAll()
        {
            return _context.Fragilidade.ToList();
        }

        public void Create(Weakness Fragilidade)
        {
            _context.Fragilidade.Add(Fragilidade);
            _context.SaveChanges();
        }

        public void Update(Weakness Fragilidade)
        {
            _context.Entry<Weakness>(Fragilidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Weakness Fragilidade)
        {
            _context.Fragilidade.Remove(Fragilidade);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
