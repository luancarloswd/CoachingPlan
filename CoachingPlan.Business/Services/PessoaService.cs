
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
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

        public Pessoa GetOne(Guid id)
        {
            var Pessoa = _repository.GetOne(id);
            if (Pessoa == null)
                throw new Exception(Errors.PersonNotFound);

            return Pessoa;
        }

        public void Register(string nome, string cpf, DateTime dataNacimneto, EGenero.Genero genero, bool status, string foto = null)
        {
            Pessoa pessoa = new Pessoa(nome, cpf, dataNacimneto, genero, status, foto);
            pessoa.Validate();

            _repository.Create(pessoa);
        }

        public void ChageInformation(Guid id, Pessoa pessoa)
        {
            var Pessoa = GetOne(id);

            Pessoa.ChangeCPF(pessoa.CPF);
            Pessoa.ChangeDataNascimento(pessoa.DataNascimento);
            Pessoa.ChangeFoto(pessoa.Foto);
            Pessoa.ChangeNome(pessoa.Nome);
            Pessoa.ChangeStatus(pessoa.Status);
            Pessoa.Validate();

            _repository.Update(Pessoa);
        }

        public void Remove(Guid id)
        {
            var Pessoa = GetOne(id);
            _repository.Delete(Pessoa);
        }
        public ICollection<Pessoa> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
