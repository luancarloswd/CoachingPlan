using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEnderecoRepository : IDisposable
    {
        Endereco GetOne(Guid id);
        List<Endereco> GetAll();
        void Create(Endereco Endereco);
        void Update(Endereco Endereco);
        void Delete(Endereco Endereco);
    }
}
