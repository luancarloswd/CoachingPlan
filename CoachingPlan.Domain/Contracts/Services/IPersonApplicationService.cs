using CoachingPlan.Domain.Commands.PersonCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IPersonApplicationService : IDisposable
    {
        Person GetOne(Guid id);
        List<Person> GetAll();
        List<Person> GetAll(int take, int skip);
        List<Person> GetAllIncludeDetails();
        Person Create(CreatePersonCommand person);
        Person Update(UpdatePersonCommand person);
        Person Delete(Guid id);
        List<Person> GetAllByNameIncludeCoach(string name);
        List<Person> GetAllByNameIncludeCoachee(string name);
        Person GetOneIncludeDetails(Guid id);
    }
}
