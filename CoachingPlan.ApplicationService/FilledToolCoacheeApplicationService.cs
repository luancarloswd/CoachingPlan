using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.FilledToolCoacheeCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class FilledToolCoacheeApplicationService : BaseApplicationService, IFilledToolCoacheeApplicationService
    {
        private IFilledToolCoacheeRepository _repository;

        public FilledToolCoacheeApplicationService(IFilledToolCoacheeRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public FilledToolCoachee Create(CreateFilledToolCoacheeCommand command)
        {
            var service = new FilledToolCoachee(command.EvaluationDate, command.IdEvaluationTool, command.IdCoachingProcess, command.IdCoachee);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public FilledToolCoachee Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<FilledToolCoachee> GetAll()
        {
            return _repository.GetAll();
        }

        public List<FilledToolCoachee> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public FilledToolCoachee GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public FilledToolCoachee Update(UpdateFilledToolCoacheeCommand command)
        {
            var FilledToolCoachee = _repository.GetOne(command.Id);
            if (command.EvaluationDate != null)
                FilledToolCoachee.ChangeEvaluationDate(command.EvaluationDate);

            _repository.Update(FilledToolCoachee);

            if (Commit())
                return FilledToolCoachee;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
