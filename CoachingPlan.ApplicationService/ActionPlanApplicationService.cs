using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.ActionPlanCommands;

namespace CoachingPlan.ApplicationService
{
    public class ActionPlanApplicationService : BaseApplicationService, IActionPlanApplicationService
    {
        private IActionPlanRepository _repository;

        public ActionPlanApplicationService(IActionPlanRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public ActionPlan Create(CreateActionPlanCommand command)
        {
            var actionPlan = new ActionPlan(command.Objective, command.CoachingProcess, command.Description);
            actionPlan.Validate();
            _repository.Create(actionPlan);

            if (Commit())
                return actionPlan;

            return null;
        }

        public ActionPlan Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<ActionPlan> GetAll()
        {
            return _repository.GetAll();
        }

        public List<ActionPlan> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public ActionPlan GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<ActionPlan> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _repository.GetAllByCoacingProcess(idCoachingProcess);
        }
        public ActionPlan Update(UpdateActionPlanCommand command)
        {
            var ActionPlan = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Description))
                ActionPlan.ChangeDescription(command.Description);

            if (command.Objective != null)
            {
                foreach (var objective in command.Objective)
                {
                    ActionPlan.AddObjective(objective);
                }
            }

            _repository.Update(ActionPlan);

            if (Commit())
                return ActionPlan;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
