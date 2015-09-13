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
        Person Create(CreatePersonCommand person);
        Person Update(CreatePersonCommand person);
        Person Delete(Guid id);
    }
}
