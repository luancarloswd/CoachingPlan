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
        public Formation GetOne(Guid id)
        {
            return _context.Formacao.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Formation> GetAll()
        {
            return _context.Formacao.ToList();
        }

        public void Create(Formation Formacao)
        {
            _context.Formacao.Add(Formacao);
            _context.SaveChanges();
        }

        public void Update(Formation Formacao)
        {
            _context.Entry<Formation>(Formacao).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Formation Formacao)
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
