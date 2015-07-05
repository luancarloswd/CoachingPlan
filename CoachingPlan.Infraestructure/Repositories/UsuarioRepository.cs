using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AppDataContext _context;

        public UsuarioRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Usuario GetOne(string id)
        {
            return _context.Usuario.Where(x => x.Id == id).FirstOrDefault();
        }
        public Usuario GetOneByEmail(string email)
        {
            return _context.Usuario.Where(x => x.Email == email).FirstOrDefault();
        }
        public List<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public void Create(Usuario Usuario)
        {
            _context.Usuario.Add(Usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario Usuario)
        {
            _context.Entry<Usuario>(Usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Usuario Usuario)
        {
            _context.Usuario.Remove(Usuario);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
