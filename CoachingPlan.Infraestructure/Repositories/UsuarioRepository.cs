using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Hosting;
using System.Web.UI;
using CoachingPlan.Domain.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            return new Usuario();
        }
        public Usuario GetOneByEmail(string email)
        {
            return new Usuario();
        }
        public List<Usuario> GetAll()
        {
            return new List<Usuario>();
        }

        public void Create(Usuario Usuario)
        {
            var manager = new UserManager<Usuario>(new UserStore<Usuario>(new AppDataContext()));
 
            manager.Create(new Usuario()
            {
                Pessoa =
                    new Pessoa("Luan Carlos Sousa Santos", "10559753659", DateTime.Now, EGenero.Genero.M, true, null),
                UserName = "teste",
                Email = "teste",
            }, "@teste");

        }

        public void Update(Usuario Usuario)
        {
            _context.Entry<Usuario>(Usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Usuario Usuario)
        {
           
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
