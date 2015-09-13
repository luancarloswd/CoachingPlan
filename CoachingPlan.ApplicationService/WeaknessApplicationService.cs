using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.WeaknessCommands;

namespace CoachingPlan.ApplicationService
{
    public class WeaknessApplicationService : BaseApplicationService, IWeaknessApplicationService
    {
        private IWeaknessRepository _repository;

        public WeaknessApplicationService(IWeaknessRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Weakness Create(CreateWeaknessCommand command)
        {
            var Weakness = new Weakness(command.Name, command.IdCoachee, command.Description);
            Weakness.Validate();
            _repository.Create(Weakness);

            if (Commit())
                return Weakness;

            return null;
        }

        public Weakness Delete(Guid id)
        {
            var Weakness = _repository.GetOne(id);
            _repository.Delete(Weakness);

            if (Commit())
                return Weakness;

            return null;
        }

        public List<Weakness> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Weakness> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Weakness GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public Weakness GetOnebyCoachee(Guid idCoachee)
        {
            return _repository.GetOneByCoachee(idCoachee);
        }
        public Weakness Update(ChangeWeaknessCommand command)
        {
            var Weakness = _repository.GetOne(command.Id);
            if(command.Name != null)
                Weakness.ChangeName(command.Name);
            if (command.Description != null)
                Weakness.ChangeDescription(command.Description);

            _repository.Update(Weakness);

            if (Commit())
                return Weakness;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
