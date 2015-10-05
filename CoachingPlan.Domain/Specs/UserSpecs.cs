using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> GetOneByPerson(Guid idPerson)
        {
            return x => x.IdPerson == idPerson;
        }

        public static Expression<Func<User, bool>> GetOneByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}
