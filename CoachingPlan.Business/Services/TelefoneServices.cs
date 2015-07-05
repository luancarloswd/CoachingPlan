
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
namespace CoachingPlan.Business.Services
{
    class TelefoneServices : ITelefoneService
    {
        private ITelefoneRepository _repository;
        public TelefoneServices(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        public Telefone GetOne(Guid id)
        {
            var telefone = _repository.GetOne(id);
            if (telefone == null)
                throw new Exception(Errors.TelefoneNotFound);

            return telefone;
        }

        public void Register(string DDD, string numero, string descricao = null)
        {
            throw new System.NotImplementedException();
        }

        public void ChageInformation(Guid id, string DDD, string numero, string descricao = null)
        {
            var telefone = GetOne(id);

            telefone.ChangeDDD(DDD);
            telefone.ChangeNumber(numero);
            telefone.ChangeDescription(descricao);
            telefone.Validate();

            _repository.Update(telefone);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
