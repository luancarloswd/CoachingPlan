using CoachingPlan.Domain.Commands.PersonCommands;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IUserApplicationService : IDisposable
    {
        User GetOne(string id);
        User GetOneByEmail(string email);
        User GetOneByName(string name);
        User GetOneByPerson(Guid idPerson);
        List<User> GetAll();
        List<User> GetAll(int take, int skip);
        User Create(CreateUserCommand commandUser);
        User Update(User user);
        User Delete(string id);
    }
}
