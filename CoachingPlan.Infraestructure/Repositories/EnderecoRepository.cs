using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private AppDataContext _context;

        public EnderecoRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Endereco GetOne(Guid id)
        {
            return _context.Endereco.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Endereco> GetAll()
        {
            return _context.Endereco.ToList();
        }

        public void Create(Endereco Endereco)
        {
            _context.Endereco.Add(Endereco);
            _context.SaveChanges();
        }

        public void Update(Endereco Endereco)
        {
            _context.Entry<Endereco>(Endereco).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Endereco Endereco)
        {
            _context.Endereco.Remove(Endereco);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
