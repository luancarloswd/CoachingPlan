using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class SpecialitySpecs
    {
        public static Expression<Func<Speciality, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Speciality, bool>> GetOneByCoach(Guid idCoach)
        {
            return x => x.IdCoach == idCoach;
        }
    }
}
