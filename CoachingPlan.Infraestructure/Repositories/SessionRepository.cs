using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using CoachingPlan.Domain.Enums;
using System.Data.Entity;

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
                return _context.Session.Where(x => x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id).ToList();
            return new List<Session>();
        }

        public List<Session> GetAllByCoachee(Person person)
        {
            var coachee = person.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id).ToList();
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
                return _context.Session.Where(x => x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id && x.Classification == classification).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByClassificationAndCoachee(ESessionClassification classification, Person person)
        {
            var coachee = person.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.Classification == classification).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByCoachAndCoachee(Person coachPerson, Person coacheePerson)
        {
            var coach = coachPerson.User.FirstOrDefault().Coach.FirstOrDefault();
            var coachee = coacheePerson.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null && coach != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByCoachAndCoacheeAndClassification(Person coachPerson, Person coacheePerson, ESessionClassification classification)
        {
            var coach = coachPerson.User.FirstOrDefault().Coach.FirstOrDefault();
            var coachee = coacheePerson.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null && coach != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id && x.Classification == classification).ToList();
            return new List<Session>();
        }
        public List<Session> GetAll(int take, int skip)
        {
            return _context.Session.OrderBy(x => x.Date).Skip(skip).Take(take).ToList();
        }

        public List<Session> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _context.Session.Where(SessionSpecs.GetAllByCoachingProcess(idCoachingProcess)).Include(x=> x.EvaluationCoachee.Select(n => n.Coachee)).ToList();
        }

        public List<Session> GetAllByCoachAndCoachingProcess(Person person, Guid idCoachingProcess)
        {
            var coach = person.User.FirstOrDefault().Coach.FirstOrDefault();
            if (coach != null)
                return _context.Session.Where(x => x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id && x.IdCoachingProcess == idCoachingProcess).ToList();
            return new List<Session>();
        }

        public List<Session> GetAllByCoacheeAndCoachingProcess(Person person, Guid idCoachingProcess)
        {
            var coachee = person.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.IdCoachingProcess == idCoachingProcess).ToList();
            return new List<Session>();
        }

        public List<Session> GetAllByClassificationAndCoachingProcess(ESessionClassification classification, Guid idCoachingProcess)
        {
            return _context.Session.Where(x => x.Classification == classification && x.IdCoachingProcess == idCoachingProcess).ToList();
        }

        public List<Session> GetAllByClassificationAndCoachAndCoachingProcess(ESessionClassification classification, Person person, Guid idCoacingProcess)
        {
            var coach = person.User.FirstOrDefault().Coach.FirstOrDefault();
            if (coach != null)
                return _context.Session.Where(x => x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id && x.Classification == classification && x.IdCoachingProcess == idCoacingProcess).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByClassificationAndCoacheeAndCoachingProcess(ESessionClassification classification, Person person, Guid idCoachingProcess)
        {
            var coachee = person.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.Classification == classification && x.IdCoachingProcess == idCoachingProcess).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByCoachAndCoacheeAndCoachingProcess(Person coachPerson, Person coacheePerson, Guid idCoachingProcess)
        {
            var coach = coachPerson.User.FirstOrDefault().Coach.FirstOrDefault();
            var coachee = coacheePerson.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null && coach != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id && x.IdCoachingProcess == idCoachingProcess).ToList();
            return new List<Session>();
        }
        public List<Session> GetAllByCoachAndCoacheeAndClassificationAndCoachingProcess(Person coachPerson, Person coacheePerson, ESessionClassification classification, Guid idCoachingProcess)
        {
            var coach = coachPerson.User.FirstOrDefault().Coach.FirstOrDefault();
            var coachee = coacheePerson.User.FirstOrDefault().Coachee.FirstOrDefault();
            if (coachee != null && coach != null)
                return _context.Session.Where(x => x.EvaluationCoachee.FirstOrDefault().IdCoachee == coachee.Id && x.EvaluationCoach.FirstOrDefault().IdCoach == coach.Id && x.Classification == classification && x.IdCoachingProcess == idCoachingProcess).ToList();
            return new List<Session>();
        }

        public Session GetOne(Guid id)
        {
            return _context.Session.Include(x => x.User.Person).Include(x => x.EvaluationCoach.Select(y=>y.Coach.User.Person)).Include(x => x.EvaluationCoachee.Select(y => y.Coachee.User.Person)).Include(x => x.Job).Where(SessionSpecs.GetOne(id)).FirstOrDefault();
        }

        public void Update(Session Session)
        {
            _context.Entry<Session>(Session).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }

    }
}
