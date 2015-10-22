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
    public class CoacheeRepository : ICoacheeRepository
    {
        AppDataContext _context;
        public CoacheeRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Coachee coachee)
        {
            _context.Coachee.Add(coachee);
        }

        public void Delete(Coachee coachee)
        {
            _context.Coachee.Remove(coachee);
        }

        public List<Coachee> GetAll()
        {
            return _context.Coachee.ToList();
        }

        public List<Coachee> GetAll(int take, int skip)
        {
            return _context.Coachee.OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public Coachee GetOne(Guid id)
        {
            return _context.Coachee.Where(CoacheeSpecs.GetOne(id)).FirstOrDefault();
        }

        public Coachee GetOneByUser(string idUser)
        {
            return _context.Coachee.Where(CoacheeSpecs.GetOneByUser(idUser)).FirstOrDefault();
        }

        public void Update(Coachee coachee)
        {
            _context.Entry<Coachee>(coachee).State = System.Data.Entity.EntityState.Modified;
        }

        public Coachee GetOneIncludeDetails(Guid id)
        {
            return _context.Coachee.Include(x => x.StrongPoint).Include(x => x.Weakness).Include(x => x.User).Include(x => x.User.Person).Include(x => x.User.Person.Phone).Include(x => x.User.Person.Address).FirstOrDefault(x => x.Id == id);
        }

        public Coachee GetOneIncludeCoachingProcess(Guid id)
        {
            return _context.Coachee.Include(x => x.CoachingProcess).FirstOrDefault(x => x.Id == id);
        }
        public List<Coachee> GetAllIncludeDetails()
        {
            return _context.Coachee.Include(x => x.User).Include(x => x.User.Person).Include(x => x.User.Person.Phone).Include(x => x.User.Person.Address).ToList();
        }
        public List<Coachee> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _context.Coachee.Where(x => x.CoachingProcess.FirstOrDefault(y => y.Id == idCoachingProcess).Id == idCoachingProcess).ToList();
        }

        public List<Coachee> GetAllIncludePerson()
        {
            return _context.Coachee.Include(x => x.User.Person).ToList();
        }
        public List<Coachee> GetAllBySession(Guid idSession)
        {
            return _context.Coachee.Where(x => x.EvaluationCoachee.FirstOrDefault(y => y.Id == idSession).Id == idSession).ToList();
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
