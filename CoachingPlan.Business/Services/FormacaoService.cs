using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class FormacaoService : IFormacaoService
    {
        private IFormacaoRepository _repository;
        public FormacaoService(IFormacaoRepository repository)
        {
            _repository = repository;
        }

        public Formation GetOne(Guid id)
        {
            var Formacao = _repository.GetOne(id);
            if (Formacao == null)
                throw new Exception(Errors.SpecialtyNotFound);

            return Formacao;
        }

        public void Register(Formation Formacao)
        {
            Formacao.Validate();

            _repository.Create(Formacao);
        }

        public void ChageInformation(Guid id, Formation formacao)
        {
            var Formacao = GetOne(id);

            Formacao.ChangeTraining(Formacao.Nome);
            Formacao.ChangeDescription(Formacao.Description);
            Formacao.Validate();

            _repository.Update(Formacao);
        }

        public void Remove(Guid id)
        {
            var Formacao = GetOne(id);
            _repository.Delete(Formacao);
        }
        public ICollection<Formation> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
