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

        public static Expression<Func<Person, bool>> GetOneByName(string name)
        {
            return x => x.Name == name;
        }
        public static Expression<Func<Person, bool>> GetOneByCPF(string cpf)
        {
            return x => x.CPF == cpf;
        }
    }
}
