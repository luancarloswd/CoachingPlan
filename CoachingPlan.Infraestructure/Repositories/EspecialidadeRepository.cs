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
        public Speciality GetOne(Guid id)
        {
            return _context.Especialidade.Where(x => x.Id == id).FirstOrDefault();
        }


        public List<Speciality> GetAll()
        {
            return _context.Especialidade.ToList();
        }

        public void Create(Speciality Especialidade)
        {
            _context.Especialidade.Add(Especialidade);
            _context.SaveChanges();
        }

        public void Update(Speciality Especialidade)
        {
            _context.Entry<Speciality>(Especialidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Speciality Especialidade)
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
