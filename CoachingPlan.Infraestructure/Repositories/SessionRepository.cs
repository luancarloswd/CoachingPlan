using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using CoachingPlan.Domain.Enums;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        AppDataContext _context;
        public SessionRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Session Session)
        {
            _context.Session.Add(Session);
        }

        public void Delete(Session Session)
        {
            _context.Session.Remove(Session);
        }

        public List<Session> GetAll()
        {
            return _context.Session.ToList();
        }

        public List<Session> GetAllByCoach(Person person)
        {
            var coach = person.User.FirstOrDefault().Coach.FirstOrDefault();
            if (coach != null)
                return _context.Session.Where(x => x.Coach.FirstOrDefault().Id == coach.Id).ToList();
            return new List<Session>();
        }

        public List<Session> GetAllByCoachee(Person person)
        {
            var coachee = person.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null)
                return _context.Session.Where(x => x.Coachee.FirstOrDefault().Id == coachee.Id).ToList();
            return new List<Session>();
        }

        public List<Session> GetAllByClassification(ESessionClassification classification)
        {
            return _context.Session.Where(SessionSpecs.GetAllByTypeSession(classification)).ToList();
        }

        public List<Session> GetAllByClassificationAndCoach(ESessionClassification classification, Person person)
        {
            var coach = person.User.FirstOrDefault().Coach.FirstOrDefault();
            if (coach != null)
                return _context.Session.Where(x => x.Coach.FirstOrDefault().Id == coach.Id && x.Classification == classification).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByClassificationAndCoachee(ESessionClassification classification, Person person)
        {
            var coachee = person.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null)
                return _context.Session.Where(x => x.Coachee.FirstOrDefault().Id == coachee.Id && x.Classification == classification).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByCoachAndCoachee(Person coachPerson, Person coacheePerson)
        {
            var coach = coachPerson.User.FirstOrDefault().Coach.FirstOrDefault();
            var coachee = coacheePerson.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null && coach != null)
                return _context.Session.Where(x => x.Coachee.FirstOrDefault().Id == coachee.Id && x.Coach.FirstOrDefault().Id == coach.Id).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByCoachAndCoacheeAndClassification(Person coachPerson, Person coacheePerson, ESessionClassification classification)
        {
            var coach = coachPerson.User.FirstOrDefault().Coach.FirstOrDefault();
            var coachee = coacheePerson.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null && coach != null)
                return _context.Session.Where(x => x.Coachee.FirstOrDefault().Id == coachee.Id && x.Coach.FirstOrDefault().Id == coach.Id && x.Classification == classification).ToList();
            return new List<Session>();
        }
        public List<Session> GetAll(int take, int skip)
        {
            return _context.Session.OrderBy(x => x.Date).Skip(skip).Take(take).ToList();
        }

        public Session GetOne(Guid id)
        {
            return _context.Session.Where(SessionSpecs.GetOne(id)).FirstOrDefault();
        }

        public void Update(Session Session)
        {
            _context.Entry<Session>(Session).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
