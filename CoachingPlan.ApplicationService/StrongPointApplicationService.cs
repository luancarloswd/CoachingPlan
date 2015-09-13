using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.SpecialityCommands;
using CoachingPlan.Domain.Commands.StrongPointCommands;

namespace CoachingPlan.ApplicationService
{
    public class StrongPointApplicationService : BaseApplicationService, IStrongPointApplicationService
    {
        private IStrongPointRepository _repository;

        public StrongPointApplicationService(IStrongPointRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public StrongPoint Create(CreateStrongPointCommand command)
        {
            var StrongPoint = new StrongPoint(command.Name, command.Class, command.IdCoachee, command.Description);
            StrongPoint.Validate();
            _repository.Create(StrongPoint);

            if (Commit())
                return StrongPoint;

            return null;
        }

        public StrongPoint Delete(Guid id)
        {
            var StrongPoint = _repository.GetOne(id);
            _repository.Delete(StrongPoint);

            if (Commit())
                return StrongPoint;

            return null;
        }

        public List<StrongPoint> GetAll()
        {
            return _repository.GetAll();
        }

        public List<StrongPoint> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public StrongPoint GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public StrongPoint GetOnebyCoachee(Guid idCoachee)
        {
            return _repository.GetOneByCoachee(idCoachee);
        }
        public StrongPoint Update(ChangeStrongPointCommand command)
        {
            var StrongPoint = _repository.GetOne(command.Id);
            if(command.Name != null)
                StrongPoint.ChangeName(command.Name);
            if (command.Description != null)
                StrongPoint.ChangeDescription(command.Description);

                StrongPoint.ChangeClass(command.Class);

            _repository.Update(StrongPoint);

            if (Commit())
                return StrongPoint;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
