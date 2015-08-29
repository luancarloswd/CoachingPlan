using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Enums;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IPessoaService : IDisposable
    {
        Person GetOne(Guid id);
        void Register(string nome, string cpf, DateTime dataNacimneto, EGenre genero, bool status, string foto = null);
        void ChageInformation(Guid id, Person Pessoa);
        void Remove(Guid id);
        ICollection<Person> GetAll(); 
    }
}
