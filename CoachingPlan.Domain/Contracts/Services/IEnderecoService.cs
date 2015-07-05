using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IEnderecoService : IDisposable
    {
        Endereco GetOne(Guid id);
        void Register(Endereco endereco);
        void ChageInformation(Guid id, Endereco endereco);
        void Remove(Guid id);
        ICollection<Endereco> GetAll(); 
    }
}
