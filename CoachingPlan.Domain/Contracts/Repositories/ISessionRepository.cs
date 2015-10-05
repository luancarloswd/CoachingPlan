﻿using CoachingPlan.Domain.Enums;
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
        List<Session> GetAll(int take, int skip);
        Session GetOne(Guid id);
        void Update(Session Session);
    }
}
