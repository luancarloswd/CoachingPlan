using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private IEspecialidadeRepository _repository;
        public EspecialidadeService(IEspecialidadeRepository repository)
        {
            _repository = repository;
        }

        public Especialidade GetOne(Guid id)
        {
            var Especialidade = _repository.GetOne(id);
            if (Especialidade == null)
                throw new Exception(Errors.SpecialtyNotFound);

            return Especialidade;
        }

        public void Register(Especialidade Especialidade)
        {
            Especialidade.Validate();

            _repository.Create(Especialidade);
        }

        public void ChageInformation(Guid id, Especialidade especialidade)
        {
            var Especialidade = GetOne(id);

            Especialidade.ChangeSpecialty(especialidade.Nome);
            Especialidade.ChangeDescription(especialidade.Descricao);
            Especialidade.Validate();

            _repository.Update(Especialidade);
        }

        public void Remove(Guid id)
        {
            var Especialidade = GetOne(id);
            _repository.Delete(Especialidade);
        }
        public ICollection<Especialidade> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
