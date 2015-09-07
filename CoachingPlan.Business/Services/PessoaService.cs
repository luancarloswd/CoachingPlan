using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Enums;

namespace CoachingPlan.Business.Services
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _repository;
        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public Person GetOne(Guid id)
        {
            var Pessoa = _repository.GetOne(id);
            if (Pessoa == null)
                throw new Exception(Errors.PersonNotFound);

            return Pessoa;
        }

        public void Register(string nome, string cpf, DateTime dataNacimneto,EGenre genero, bool status, string foto = null)
        {
            Person pessoa = new Person(nome, cpf, dataNacimneto, genero, status, foto);
            pessoa.Validate();

            _repository.Create(pessoa);
        }

        public void ChageInformation(Guid id, Person pessoa)
        {
            var Pessoa = GetOne(id);

            Pessoa.ChangeCPF(pessoa.CPF);
            Pessoa.ChangeBirthDate(pessoa.BirthDate);
            Pessoa.ChangePhotograph(pessoa.Photograph);
            Pessoa.ChangeName(pessoa.Name);
            Pessoa.ChangeStatus(pessoa.Status);
            Pessoa.Validate();

            _repository.Update(Pessoa);
        }

        public void Remove(Guid id)
        {
            var Pessoa = GetOne(id);
            _repository.Delete(Pessoa);
        }
        public ICollection<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
