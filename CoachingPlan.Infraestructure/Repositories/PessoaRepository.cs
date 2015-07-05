using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private AppDataContext _context;

        public PessoaRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Pessoa GetOne(Guid id)
        {
            return _context.Pessoa.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Pessoa> GetAll()
        {
            return _context.Pessoa.ToList();
        }

        public void Create(Pessoa Pessoa)
        {
            _context.Pessoa.Add(Pessoa);
            _context.SaveChanges();
        }

        public void Update(Pessoa Pessoa)
        {
            _context.Entry<Pessoa>(Pessoa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Pessoa Pessoa)
        {
            _context.Pessoa.Remove(Pessoa);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
