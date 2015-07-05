
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class CoacheeService : ICoacheeService
    {
        private ICoacheeRepository _repository;
        public CoacheeService(ICoacheeRepository repository)
        {
            _repository = repository;
        }

        public Coachee GetOne(Guid id)
        {
            var Coachee = _repository.GetOne(id);
            if (Coachee == null)
                throw new Exception(Errors.CoacheeNotFound);

            return Coachee;
        }

        public void Register(Coachee Coachee)
        {
            Coachee.Validate();

            _repository.Create(Coachee);
        }

        public void ChageInformation(Guid id, Coachee coachee)
        {
            var Coachee = GetOne(id);

            Coachee.ChangeProfession(coachee.Profissao);
            Coachee.Validate();

            _repository.Update(Coachee);
        }

        public void Remove(Guid id)
        {
            var Coachee = GetOne(id);
            _repository.Delete(Coachee);
        }
        public ICollection<Coachee> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
