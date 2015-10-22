using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.CoachingProcessCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class CoachingProcessApplicationService : BaseApplicationService, ICoachingProcessApplicationService
    {
        private ICoachingProcessRepository _repository;

        public CoachingProcessApplicationService(ICoachingProcessRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public CoachingProcess Create(CreateCoachingProcessCommand command)
        {
            var coachingProcess = new CoachingProcess(command.Name, command.StartDate, command.Mode, command.Budget, command.Session, command.PerformaceIndicator, command.Coachee, command.Coach, command.Service, command.EndDate, command.Observation);
            coachingProcess.Validate();
            _repository.Create(coachingProcess);

            if (Commit())
                return coachingProcess;

            return null;
        }

        public CoachingProcess Delete(Guid id)
        {
            var coachingProcess = _repository.GetOne(id);
            _repository.Delete(coachingProcess);

            if (Commit())
                return coachingProcess;

            return null;
        }

        public List<CoachingProcess> GetAll()
        {
            return _repository.GetAll();
        }

        public CoachingProcess GetOneIncludeDetails(Guid id)
        {
            return _repository.GetOneIncludeDetails(id);
        }

        public List<CoachingProcess> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public CoachingProcess GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<CoachingProcess> GetAllByService(Guid idService)
        {
            return _repository.GetAllByService(idService);
        }
        public CoachingProcess Update(UpdateCoachingProcessCommand command)
        {
            var coachingProcess = _repository.GetOneIncludeDetails(command.Id);

            if (!string.IsNullOrEmpty(command.Name))
                coachingProcess.ChangeName(command.Name);
            if (command.StartDate != DateTime.MinValue)
                coachingProcess.ChangeStartDate(command.StartDate);
            if (command.Mode != 0)
                coachingProcess.ChangeMode(command.Mode);
            if (command.EndDate != DateTime.MinValue)
                coachingProcess.ChangeEndDate(command.EndDate);
            if (command.Observation != null)
                coachingProcess.ChangeObservation(command.Observation);
            if (command.PerformaceIndicator != null)
            {
                foreach (var performanceIndicator in command.PerformaceIndicator)
                {
                    coachingProcess.AddPerformanceIndicator(performanceIndicator);
                }
            }
            if (command.Service != null)
            {
                foreach (var service in command.Service)
                {
                    coachingProcess.AddService(service);
                }
            }

            if (command.Budget != null)
            {
                foreach (var budget in command.Budget)
                {
                    coachingProcess.AddBudget(budget);
                }
            }
            if (command.Coach != null)
            {
                foreach (var coach in command.Coach)
                {
                    coachingProcess.AddCoach(coach);
                }
            }
            if (command.Session != null)
            {
                foreach (var coachee in command.Coachee)
                {
                    coachingProcess.AddCoachee(coachee);
                }
            }
            if (command.Session != null)
            {
                foreach (var session in command.Session)
                {
                    coachingProcess.AddSession(session);
                }
            }

            _repository.Update(coachingProcess);

            if (Commit())
                return coachingProcess;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
