using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class PhoneSpecs
    {
        public static Expression<Func<Phone, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Phone, bool>> GetOneByPerson(Guid idPerson)
        {
            return x => x.IdPerson == idPerson;
        }
    }
}
