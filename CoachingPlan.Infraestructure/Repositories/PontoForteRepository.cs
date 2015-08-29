using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    //public class PontoForteRepository : IPontoForteRepository
    //{
    //    private AppDataContext _context;

    //    public PontoForteRepository(AppDataContext context)
    //    {
    //        this._context = context;
    //    }
    //    public StrongPoint GetOne(Guid id)
    //    {
    //        return _context.PontoForte.Where(x => x.Id == id).FirstOrDefault();
    //    }
    //    public List<StrongPoint> GetAll()
    //    {
    //        return _context.PontoForte.ToList();
    //    }

    //    public void Create(StrongPoint PontoForte)
    //    {
    //        _context.PontoForte.Add(PontoForte);
    //        _context.SaveChanges();
    //    }

    //    public void Update(StrongPoint PontoForte)
    //    {
    //        _context.Entry<StrongPoint>(PontoForte).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void Delete(StrongPoint PontoForte)
    //    {
    //        _context.PontoForte.Remove(PontoForte);
    //        _context.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }
    //}
}
