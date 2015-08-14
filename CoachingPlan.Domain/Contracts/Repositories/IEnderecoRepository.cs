using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IEnderecoRepository : IDisposable
    {
        Address GetOne(Guid id);
        List<Address> GetAll();
        void Create(Address Endereco);
        void Update(Address Endereco);
        void Delete(Address Endereco);
    }
}
