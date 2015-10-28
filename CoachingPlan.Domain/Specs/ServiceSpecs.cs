using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class ServiceSpecs
    {
        public static Expression<Func<Service, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Service, bool>> GetOneByName(string name)
        {
            return x => x.Name == name;
        }
    }
}
