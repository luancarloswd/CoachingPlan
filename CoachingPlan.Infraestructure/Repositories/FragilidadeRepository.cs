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
        public Fragilidade GetOne(Guid id)
        {
            return _context.Fragilidade.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Fragilidade> GetAll()
        {
            return _context.Fragilidade.ToList();
        }

        public void Create(Fragilidade Fragilidade)
        {
            _context.Fragilidade.Add(Fragilidade);
            _context.SaveChanges();
        }

        public void Update(Fragilidade Fragilidade)
        {
            _context.Entry<Fragilidade>(Fragilidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Fragilidade Fragilidade)
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
