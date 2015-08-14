using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEnderecoService : IDisposable
    {
        Address GetOne(Guid id);
        void Register(Address endereco);
        void ChageInformation(Guid id, Address endereco);
        void Remove(Guid id);
        ICollection<Address> GetAll(); 
    }
}
