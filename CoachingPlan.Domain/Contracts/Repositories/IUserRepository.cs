using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace UseringPlan.Domain.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetOne(Guid id);
        List<User> GetAll();
        List<User> GetAll(int take, int skip);
        void Create(User User);
        void Update(User User);
        void Delete(User User);
    }
}
