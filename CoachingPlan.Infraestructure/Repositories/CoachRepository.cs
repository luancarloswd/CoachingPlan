using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    //public class CoachRepository : ICoachRepository
    //{
    //    private AppDataContext _context;

    //    public CoachRepository(AppDataContext context)
    //    {
    //        this._context = context;
    //    }
    //    public Coach GetOne(Guid id)
    //    {
    //        return _context.Coach.Where(x => x.Id == id).FirstOrDefault();
    //    }
    //    public List<Coach> GetAll()
    //    {
    //        return _context.Coach.ToList();
    //    }

    //    public void Create(Coach Coach)
    //    {
    //        _context.Coach.Add(Coach);
    //        _context.SaveChanges();
    //    }

    //    public void Update(Coach Coach)
    //    {
    //        _context.Entry<Coach>(Coach).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void Delete(Coach Coach)
    //    {
    //        _context.Coach.Remove(Coach);
    //        _context.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }
    //}
}
