using CoachingPlan.Domain.Commands.PersonCommands;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        List<User> GetAllIncludeDetails();
        List<User> GetAll(int take, int skip);
        User Create(CreateUserCommand commandUser);
        void AddRole(string id, string role);
        User Update(UpdateUserCommand commandUser);
        User Delete(string id);
        User Authenticate(string userName, string password);
        ICollection<string> GetAllRoles(string id);
        ClaimsIdentity GenerateUserIdentityAsync(User user, string authenticationType);
        User GetOneByEmailIncludePerson(string email);
        User GetOneIncludeDetails(string id);
    }
}
