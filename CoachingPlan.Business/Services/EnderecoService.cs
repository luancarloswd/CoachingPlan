
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class EnderecoService : IEnderecoService
    {
        private IEnderecoRepository _repository;
        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public Address GetOne(Guid id)
        {
            var Endereco = _repository.GetOne(id);
            if (Endereco == null)
                throw new Exception(Errors.EnderecoNotFound);

            return Endereco;
        }

        public void Register(Address Endereco)
        {
            Endereco.Validate();

            _repository.Create(Endereco);
        }

        public void ChageInformation(Guid id, Address endereco)
        {
            var Endereco = GetOne(id);

            Endereco.ChangeTipo(endereco.Type);
            Endereco.ChangeCEP(endereco.CEP);
            Endereco.ChangeCidade(endereco.City);
            Endereco.ChangeEstado(endereco.State);
            Endereco.ChangeNumero(endereco.Numero);
            Endereco.ChangeRua(endereco.Street);
            Endereco.Validate();

            _repository.Update(Endereco);
        }

        public void Remove(Guid id)
        {
            var Endereco = GetOne(id);
            _repository.Delete(Endereco);
        }
        public ICollection<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
