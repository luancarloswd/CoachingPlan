using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class CoachSpecs
    {
        public static Expression<Func<Coach, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Coach, bool>> GetOneByUser(string idUser)
        {
            return x => x.IdUser == idUser;
        }
    }
}
