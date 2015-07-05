using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private AppDataContext _context;

        public TelefoneRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Telefone GetOne(Guid id)
        {
            return _context.Telefone.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Telefone> GetAll()
        {
            return _context.Telefone.ToList();
        }

        public void Create(Telefone Telefone)
        {
            _context.Telefone.Add(Telefone);
            _context.SaveChanges();
        }

        public void Update(Telefone Telefone)
        {
            _context.Entry<Telefone>(Telefone).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Telefone Telefone)
        {
            _context.Telefone.Remove(Telefone);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
