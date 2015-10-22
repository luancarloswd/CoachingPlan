using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
        public Coach GetOneIncludeDetails(Guid id)
        {
            return _context.Coach.Include(x => x.Formation).Include(x => x.Speciality).Include(x => x.User).Include(x => x.User.Person).Include(x => x.User.Person.Phone).Include(x => x.User.Person.Address).FirstOrDefault(x => x.Id == id);
        }
        public Coach GetOneByUser(string idUser)
        {
            return _context.Coach.Where(CoachSpecs.GetOneByUser(idUser)).FirstOrDefault();
        }
        public List<Coach> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _context.Coach.Where(x => x.CoachingProcess.FirstOrDefault(y => y.Id == idCoachingProcess).Id == idCoachingProcess).ToList();
        }
        public void Update(Coach coach)
        {
            _context.Entry<Coach>(coach).State = System.Data.Entity.EntityState.Modified;
        }

        public List<Coach> GetAllIncludeDetails()
        {
            return _context.Coach.Include(x => x.User).Include(x => x.User.Person).Include(x => x.User.Person.Phone).Include(x => x.User.Person.Address).ToList();
        }

        public List<Coach> GetAllIncludePerson()
        {
            return _context.Coach.Include(x => x.User.Person).ToList();
        }
        public Coach GetOneIncludeCoachingProcess(Guid id)
        {
            return _context.Coach.Include(x => x.CoachingProcess).FirstOrDefault(x => x.Id == id);
        }
        public List<Coach> GetAllBySession(Guid idSession)
        {
            return _context.Coach.ToList();
            //return _context.Coach.Where(x => x.Session.FirstOrDefault(y => y.Id == idSession).Id == idSession).ToList();
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
