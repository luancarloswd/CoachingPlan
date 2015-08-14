using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        User GetOne(string id);
        User GetOneByEmail(string email);
        List<User> GetAll();
        void Create(User Usuario);
        void Update(User Usuario);
        void Delete(User Usuario);
    }
}
