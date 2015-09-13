using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.SpecialityCommands;

namespace CoachingPlan.ApplicationService
{
    public class SpecialityApplicationService : BaseApplicationService, ISpecialityApplicationService
    {
        private ISpecialityRepository _repository;

        public SpecialityApplicationService(ISpecialityRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Speciality Create(CreateSpecialityCommand command)
        {
            var speciality = new Speciality(command.Name, command.IdCoach, command.Description);
            speciality.Validate();
            _repository.Create(speciality);

            if (Commit())
                return speciality;

            return null;
        }

        public Speciality Delete(Guid id)
        {
            var speciality = _repository.GetOne(id);
            _repository.Delete(speciality);

            if (Commit())
                return speciality;

            return null;
        }

        public List<Speciality> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Speciality> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Speciality GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public Speciality GetOnebyCoach(Guid idCoach)
        {
            return _repository.GetOneByCoach(idCoach);
        }
        public Speciality Update(ChangeSpecialityCommand command)
        {
            var speciality = _repository.GetOne(command.Id);
            if(command.Name != null)
                speciality.ChangeName(command.Name);
            if (command.Description != null)
                speciality.ChangeDescription(command.Description);

            _repository.Update(speciality);

            if (Commit())
                return speciality;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
