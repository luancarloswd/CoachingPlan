using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.FilledToolCoachCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class FilledToolCoachApplicationService : BaseApplicationService, IFilledToolCoachApplicationService
    {
        private IFilledToolCoachRepository _repository;

        public FilledToolCoachApplicationService(IFilledToolCoachRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public FilledToolCoach Create(CreateFilledToolCoachCommand command)
        {
            var service = new FilledToolCoach(command.EvaluationDate, command.IdEvaluationTool, command.idCoachingProcess, command.IdCoach);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public FilledToolCoach Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<FilledToolCoach> GetAll()
        {
            return _repository.GetAll();
        }

        public List<FilledToolCoach> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public FilledToolCoach GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public FilledToolCoach Update(UpdateFilledToolCoachCommand command)
        {
            var FilledToolCoach = _repository.GetOne(command.Id);
            if (command.EvaluationDate != null)
                FilledToolCoach.ChangeEvaluationDate(command.EvaluationDate);

            _repository.Update(FilledToolCoach);

            if (Commit())
                return FilledToolCoach;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
