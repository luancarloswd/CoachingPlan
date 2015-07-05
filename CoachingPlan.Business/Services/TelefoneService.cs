
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class TelefoneService : ITelefoneService
    {
        private ITelefoneRepository _repository;
        public TelefoneService(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        public Telefone GetOne(Guid id)
        {
            var Telefone = _repository.GetOne(id);
            if (Telefone == null)
                throw new Exception(Errors.TelefoneNotFound);

            return Telefone;
        }

        public void Register(Telefone telefone)
        {
            telefone.Validate();

            _repository.Create(telefone);
        }

        public void ChageInformation(Guid id, Telefone telefone)
        {
            var Telefone = GetOne(id);

            Telefone.ChangeDDD(telefone.DDD);
            Telefone.ChangeNumber(telefone.Numero);
            Telefone.ChangeDescription(telefone.Descricao);
            Telefone.Validate();

            _repository.Update(telefone);
        }

        public void Remove(Guid id)
        {
            var Telefone = GetOne(id);
            _repository.Delete(Telefone);
        }
        public ICollection<Telefone> GetAll()
        {
            return _repository.GetAll();
        }


        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
