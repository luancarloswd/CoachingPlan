using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ISessionRepository : IDisposable
    {
        void Create(Session Session);
        void Delete(Session Session);
        List<Session> GetAll();
        List<Session> GetAllByCoach(Person coach);
        List<Session> GetAllByCoachee(Person coachee);
        List<Session> GetAllByClassification(ESessionClassification classification);
        List<Session> GetAllByClassificationAndCoach(ESessionClassification classification, Person coach);
        List<Session> GetAllByClassificationAndCoachee(ESessionClassification classification, Person coachee);
        List<Session> GetAllByCoachAndCoachee(Person coach, Person coachee);
        List<Session> GetAllByCoachAndCoacheeAndClassification(Person coach, Person coachee, ESessionClassification classification);
        List<Session> GetAllByCoachingProcess(Guid idCoachingProcess);
        List<Session> GetAllByCoachAndCoachingProcess(Person coach, Guid idCoachingProcess);
        List<Session> GetAllByCoacheeAndCoachingProcess(Person coachee, Guid idCoachingProcess);
        List<Session> GetAllByClassificationAndCoachingProcess(ESessionClassification classification, Guid idCoachingProcess);
        List<Session> GetAllByClassificationAndCoachAndCoachingProcess(ESessionClassification classification, Person coach, Guid idCoachingProcess);
        List<Session> GetAllByClassificationAndCoacheeAndCoachingProcess(ESessionClassification classification, Person coachee, Guid idCoachingprocess);
        List<Session> GetAllByCoachAndCoacheeAndCoachingProcess(Person coach, Person coachee, Guid idCoachingProcess);
        List<Session> GetAllByCoachAndCoacheeAndClassificationAndCoachingProcess(Person coach, Person coachee, ESessionClassification classification, Guid idCoachingProcess);
        List<Session> GetAll(int take, int skip);
        List<Session> GetAllIncludeDetails();
        Session GetOne(Guid id);
        void Update(Session Session);
    }
}
