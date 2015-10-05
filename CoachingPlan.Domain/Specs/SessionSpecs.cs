using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class SessionSpecs
    {
        public static Expression<Func<Session, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Session, bool>> GetAllByCoach(Coach coach)
        {
            return x => x.Coach.Contains(coach);
        }
        public static Expression<Func<Session, bool>> GetAllByCoachee(Coachee coachee)
        {
            return x => x.Coachee == coachee;
        }
        public static Expression<Func<Session, bool>> GetAllByTypeSession(ESessionClassification classification)
        {
            return x => x.Classification == classification;
        }
        public static Expression<Func<Session, bool>> GetAllByTypeSessionAndCoach(ESessionClassification classification, Coach coach)
        {
            return x => x.Classification == classification && x.Coach == coach;
        }

        public static Expression<Func<Session, bool>> GetAllByTypeSessionAndCoachee(ESessionClassification classification, Coachee coachee)
        {
            return x => x.Classification == classification && x.Coachee == coachee;
        }
        public static Expression<Func<Session, bool>> GetAllByCoachAndCoachee(Coach coach, Coachee coachee)
        {
            return x => x.Coach == coach && x.Coachee == coachee;
        }

        public static Expression<Func<Session, bool>> GetAllByCoachAndCoacheeAndClassification(Coach coach, Coachee coachee, ESessionClassification classification)
        {
            return x => x.Coach == coach && x.Coachee == coachee && x.Classification == classification;
        }
    }
}
