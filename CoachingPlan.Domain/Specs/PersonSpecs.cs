using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class PersonSpecs
    {
        public static Expression<Func<Person, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }

    }
}
