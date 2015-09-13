using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class CoacheeSpecs
    {
        public static Expression<Func<Coachee, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Coachee, bool>> GetOneByUser(string idUser)
        {
            return x => x.IdUser == idUser;
        }
    }
}
