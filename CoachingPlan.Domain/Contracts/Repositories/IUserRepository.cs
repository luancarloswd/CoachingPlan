using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetOne(string id);
        User GetOneByEmail(string email);
        User GetOneByName(string name);
        User GetOneByPerson(Guid idPerson);
        List<User> GetAll();
        List<User> GetAll(int take, int skip);
        void Create(User user, string password);
        void Update(User user);
        void Delete(User user);
        void AddRole(string id, string role);
        User Authenticate(string userName, string password);
        ClaimsIdentity GenerateUserIdentityAsync(User user, string authenticationType);
        ICollection<string> GetAllRoles(string id);
        List<User> GetAllIncludeDetails();
        User GetOneByEmailIncludePerson(string email);
        User GetOneIncludeDetails(string id);
        string GenerateTokenRecoveryPassword(string id);
        void RecoveryPassword(string idUser, string token, string password);
        void SendEmail(string idUser, string subject, string body);
    }
}
