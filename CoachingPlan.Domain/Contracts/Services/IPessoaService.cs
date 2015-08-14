using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Enums;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IPessoaService : IDisposable
    {
        People GetOne(Guid id);
        void Register(string nome, string cpf, DateTime dataNacimneto, EGenero.Genero genero, bool status, string foto = null);
        void ChageInformation(Guid id, People Pessoa);
        void Remove(Guid id);
        ICollection<People> GetAll(); 
    }
}
