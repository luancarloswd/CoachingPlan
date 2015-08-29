using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPessoaRepository : IDisposable
    {
        Person GetOne(Guid id);
        List<Person> GetAll();
        void Create(Person Pessoa);
        void Update(Person Pessoa);
        void Delete(Person Pessoa);
    }
}
