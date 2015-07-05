using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class FormacaoRepository : IFormacaoRepository
    {
        private AppDataContext _context;

        public FormacaoRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Formacao GetOne(Guid id)
        {
            return _context.Formacao.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Formacao> GetAll()
        {
            return _context.Formacao.ToList();
        }

        public void Create(Formacao Formacao)
        {
            _context.Formacao.Add(Formacao);
            _context.SaveChanges();
        }

        public void Update(Formacao Formacao)
        {
            _context.Entry<Formacao>(Formacao).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Formacao Formacao)
        {
            _context.Formacao.Remove(Formacao);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
