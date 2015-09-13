using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class AddressSpecs
    {
        public static Expression<Func<Address, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Address, bool>> GetOneByPerson(Guid idPerson)
        {
            return x => x.IdPerson == idPerson;
        }
    }
}
