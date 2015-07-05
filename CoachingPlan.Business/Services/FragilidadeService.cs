using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class FragilidadeService : IFragilidadeService
    {
        private IFragilidadeRepository _repository;
        public FragilidadeService(IFragilidadeRepository repository)
        {
            _repository = repository;
        }

        public Fragilidade GetOne(Guid id)
        {
            var Fragilidade = _repository.GetOne(id);
            if (Fragilidade == null)
                throw new Exception(Errors.SpecialtyNotFound);

            return Fragilidade;
        }

        public void Register(Fragilidade Fragilidade)
        {
            Fragilidade.Validate();

            _repository.Create(Fragilidade);
        }

        public void ChageInformation(Guid id, Fragilidade fragilidade)
        {
            var Fragilidade = GetOne(id);

            Fragilidade.ChangeWeakness(fragilidade.Nome);
            Fragilidade.ChangeDescription(fragilidade.Descricao);
            Fragilidade.Validate();

            _repository.Update(Fragilidade);
        }

        public void Remove(Guid id)
        {
            var Fragilidade = GetOne(id);
            _repository.Delete(Fragilidade);
        }
        public ICollection<Fragilidade> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
