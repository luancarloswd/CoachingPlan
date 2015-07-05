using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private AppDataContext _context;

        public EspecialidadeRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Especialidade GetOne(Guid id)
        {
            return _context.Especialidade.Where(x => x.Id == id).FirstOrDefault();
        }


        public List<Especialidade> GetAll()
        {
            return _context.Especialidade.ToList();
        }

        public void Create(Especialidade Especialidade)
        {
            _context.Especialidade.Add(Especialidade);
            _context.SaveChanges();
        }

        public void Update(Especialidade Especialidade)
        {
            _context.Entry<Especialidade>(Especialidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Especialidade Especialidade)
        {
            _context.Especialidade.Remove(Especialidade);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
