using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class PontoForteRepository : IPontoForteRepository
    {
        private AppDataContext _context;

        public PontoForteRepository(AppDataContext context)
        {
            this._context = context;
        }
        public PontoForte GetOne(Guid id)
        {
            return _context.PontoForte.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<PontoForte> GetAll()
        {
            return _context.PontoForte.ToList();
        }

        public void Create(PontoForte PontoForte)
        {
            _context.PontoForte.Add(PontoForte);
            _context.SaveChanges();
        }

        public void Update(PontoForte PontoForte)
        {
            _context.Entry<PontoForte>(PontoForte).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(PontoForte PontoForte)
        {
            _context.PontoForte.Remove(PontoForte);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
