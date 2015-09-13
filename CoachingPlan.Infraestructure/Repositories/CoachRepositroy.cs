using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        AppDataContext _context;
        public CoachRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Coach coach)
        {
            _context.Coach.Add(coach);
        }

        public void Delete(Coach coach)
        {
            _context.Coach.Remove(coach);
        }

        public List<Coach> GetAll()
        {
            return _context.Coach.ToList();
        }

        public List<Coach> GetAll(int take, int skip)
        {
            return _context.Coach.OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public Coach GetOne(Guid id)
        {
            return _context.Coach.Where(CoachSpecs.GetOne(id)).FirstOrDefault();
        }

        public Coach GetOneByUser(string idUser)
        {
            return _context.Coach.Where(CoachSpecs.GetOneByUser(idUser)).FirstOrDefault();
        }

        public void Update(Coach coach)
        {
            _context.Entry<Coach>(coach).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
