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
    //public class UsuarioRepository : IUsuarioRepository
    //{
    //    private AppDataContext _context;

    //    public UsuarioRepository(AppDataContext context)
    //    {
    //        this._context = context;
    //    }
    //    public User GetOne(string id)
    //    {
    //        return new User();
    //    }
    //    public User GetOneByEmail(string email)
    //    {
    //        return new User();
    //    }
    //    public List<User> GetAll()
    //    {
    //        return new List<User>();
    //    }

    //    public void Create(User Usuario)
    //    {
    //        var manager = new UserManager<User>(new UserStore<User>(new AppDataContext()));
 
    //        manager.Create(new User()
    //        {
    //            Pessoa =
    //                new Person("Luan Carlos Sousa Santos", "10559753659", DateTime.Now, EGenero.Genero.M, true, null),
    //            UserName = "teste",
    //            Email = "teste",
    //        }, "@teste");

    //    }

    //    public void Update(User Usuario)
    //    {
    //        _context.Entry<User>(Usuario).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void Delete(User Usuario)
    //    {
           
    //        _context.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }
    //}
}
