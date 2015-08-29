using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    //public class TelefoneRepository : ITelefoneRepository
    //{
    //    private AppDataContext _context;

    //    public TelefoneRepository(AppDataContext context)
    //    {
    //        this._context = context;
    //    }
    //    public Phone GetOne(Guid id)
    //    {
    //        return _context.Telefone.Where(x => x.Id == id).FirstOrDefault();
    //    }

    //    public List<Phone> GetAll()
    //    {
    //        return _context.Telefone.ToList();
    //    }

    //    public void Create(Phone Telefone)
    //    {
    //        _context.Telefone.Add(Telefone);
    //        _context.SaveChanges();
    //    }

    //    public void Update(Phone Telefone)
    //    {
    //        _context.Entry<Phone>(Telefone).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void Delete(Phone Telefone)
    //    {
    //        _context.Telefone.Remove(Telefone);
    //        _context.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }
    //}
}
