using CoachingPlan.Domain.Commands.SessionCommands;
using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface ISessionApplicationService : IDisposable
    {
        Session Create(CreateSessionCommand Session);
        Session Delete(Guid idSession);
        List<Session> GetAll();
        List<Session> GetAllByCoach(Person coach);
        List<Session> GetAllByCoachee(Person coachee);
        List<Session> GetAllByClassification(ESessionClassification classification);
        List<Session> GetAllByClassificationAndCoach(ESessionClassification classification, Person coach);
        List<Session> GetAllByClassificationAndCoachee(ESessionClassification classification, Person coachee);
        List<Session> GetAllByCoachAndCoachee(Person coach, Person coachee);
        List<Session> GetAllByCoachAndCoacheeAndClassification(Person coach, Person coachee, ESessionClassification classification);
        List<Session> GetAll(int take, int skip);
        Session GetOne(Guid id);
        Session Update(UpdateSessionCommand command);
        List<Session> GetAllByCoachingProcess(Guid idCoachingProcess);
        List<Session> GetAllByCoachAndCoachingProcess(Person coach, Guid idCoachingPrcess);
        List<Session> GetAllByCoacheeAndCoachingProcess(Person coachee, Guid idCoachingProcess);
        List<Session> GetAllByClassificationAndCoachingProcess(ESessionClassification classification, Guid idCoachinProcess);
        List<Session> GetAllByClassificationAndCoachAndCoachingProcess(ESessionClassification classification, Person coach, Guid idCoachinProcess);
        List<Session> GetAllByClassificationAndCoacheeAndCoachingProcess(ESessionClassification classification, Person coachee, Guid idCoachingProcess);
        List<Session> GetAllByCoachAndCoacheeAndCoachingProcess(Person coach, Person coachee, Guid idCoachingProcess);
        List<Session> GetAllByCoachAndCoacheeAndClassificationAndCoachingProcess(Person coach, Person coachee, ESessionClassification classification, Guid idCoachingProcess);
    }
}
