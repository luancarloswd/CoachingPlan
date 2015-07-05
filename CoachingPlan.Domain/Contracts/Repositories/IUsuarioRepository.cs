using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario GetOne(string id);
        Usuario GetOneByEmail(string email);
        List<Usuario> GetAll();
        void Create(Usuario Usuario);
        void Update(Usuario Usuario);
        void Delete(Usuario Usuario);
    }
}
