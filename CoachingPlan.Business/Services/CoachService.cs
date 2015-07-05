
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    public class CoachService : ICoachService
    {
        private ICoachRepository _repository;
        public CoachService(ICoachRepository repository)
        {
            _repository = repository;
        }

        public Coach GetOne(Guid id)
        {
            var Coach = _repository.GetOne(id);
            if (Coach == null)
                throw new Exception(Errors.CoachNotFound);

            return Coach;
        }

        public void Register(Coach Coach)
        {
            _repository.Create(Coach);
        }

        public void ChageInformation(Guid id, Coach coach)
        {
            var Coach = GetOne(id);

            _repository.Update(coach);
        }

        public void Remove(Guid id)
        {
            var Coach = GetOne(id);
            _repository.Delete(Coach);
        }
        public ICollection<Coach> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
