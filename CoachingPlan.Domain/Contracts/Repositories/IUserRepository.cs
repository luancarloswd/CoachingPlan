using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<User> GetOne(string id);
        Task<User> GetOneByEmail(string email);
        Task<User> GetOneByName(string name);
        User GetOneByPerson(Guid idPerson);
        List<User> GetAll();
        List<User> GetAll(int take, int skip);
        void Create(User user, string password);
        void Update(User user);
        void Delete(User user);
        Task<User> Authenticate(string userName, string password);
    }
}
