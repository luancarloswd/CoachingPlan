using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ITelefoneService : IDisposable
    {
        Phone GetOne(Guid id);
        void Register(string ddd, string numero, string descricao = null);
        void ChageInformation(Guid id, Phone Telefone);
        void Remove(Guid id);
        ICollection<Phone> GetAll(); 
    }
}
