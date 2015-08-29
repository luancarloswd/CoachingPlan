using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    //public class CoacheeRepository : ICoacheeRepository
    //{
    //    private AppDataContext _context;

    //    public CoacheeRepository(AppDataContext context)
    //    {
    //        this._context = context;
    //    }
    //    public Coachee GetOne(Guid id)
    //    {
    //        return _context.Coachee.Where(x => x.Id == id).FirstOrDefault();
    //    }
    //    public List<Coachee> GetAll()
    //    {
    //        return _context.Coachee.ToList();
    //    }

    //    public void Create(Coachee Coachee)
    //    {
    //        _context.Coachee.Add(Coachee);
    //        _context.SaveChanges();
    //    }

    //    public void Update(Coachee Coachee)
    //    {
    //        _context.Entry<Coachee>(Coachee).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void Delete(Coachee Coachee)
    //    {
    //        _context.Coachee.Remove(Coachee);
    //        _context.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }
    //}
}
