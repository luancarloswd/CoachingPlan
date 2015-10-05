using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.ApplicationService
{
    public class SessionApplicationService : BaseApplicationService, ISessionApplicationService
    {
        private ISessionRepository _repositorySession;
        private ICoacheeRepository _repositoryCoachee;
        private ICoachRepository _repositoryCoach;

        public SessionApplicationService(ISessionRepository repositorySession, ICoacheeRepository repositoryCoachee, ICoachRepository repositoryCoach,  IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repositorySession = repositorySession;
            this._repositoryCoachee = repositoryCoachee;
            this._repositoryCoach = repositoryCoach;
        }
      

        public void Dispose()
        {
            _repositorySession = null;
        }

        public Session Create(Session Session)
        {
            throw new NotImplementedException();
        }

        public Session Delete(Session Session)
        {
            throw new NotImplementedException();
        }

        public List<Session> GetAll()
        {
            return _repositorySession.GetAll();
        }

        public List<Session> GetAllByCoach(Person coach)
        {
            return _repositorySession.GetAllByCoach(coach);
        }

        public List<Session> GetAllByCoachee(Person coachee)
        {
            return _repositorySession.GetAllByCoachee(coachee);
        }

        public List<Session> GetAllByClassification(ESessionClassification classification)
        {
            return _repositorySession.GetAllByClassification(classification);
        }

        public List<Session> GetAllByClassificationAndCoach(ESessionClassification classification, Person coach)
        {
            return _repositorySession.GetAllByClassificationAndCoach(classification, coach);
        }

        public List<Session> GetAllByClassificationAndCoachee(ESessionClassification classification, Person coachee)
        {
            return _repositorySession.GetAllByClassificationAndCoachee(classification, coachee);
        }

        public List<Session> GetAllByCoachAndCoachee(Person coach, Person coachee)
        {
            return _repositorySession.GetAllByCoachAndCoachee(coach, coachee);
        }

        public List<Session> GetAllByCoachAndCoacheeAndClassification(Person coach, Person coachee, ESessionClassification classification)
        {
            return _repositorySession.GetAllByCoachAndCoacheeAndClassification(coach, coachee, classification);
        }

        public List<Session> GetAll(int take, int skip)
        {
            return _repositorySession.GetAll(take, skip);
        }

        public Session GetOne(Guid id)
        {
            return _repositorySession.GetOne(id);
        }

        public Session Update(Session Session)
        {
            throw new NotImplementedException();
        }
    }
}
