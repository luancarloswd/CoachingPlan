using CoachingPlan.Domain.Commands.PersonCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPersonRepository : IDisposable
    {
        Person GetOne(Guid id);
        List<Person> GetAll();
        List<Person> GetAll(int take, int skip);
        List<Person> GetAllIncludeDetails();
        void Create(Person Person);
        void Update(Person Person);
        void Delete(Person Person);
        List<Person> GetAllByNameIncludeCoach(string name);
        List<Person> GetAllByNameIncludeCoachee(string name);
        Person GetOneIncludeDetails(Guid id);
    }
}
