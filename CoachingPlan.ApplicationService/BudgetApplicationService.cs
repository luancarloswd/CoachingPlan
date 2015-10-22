using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.BudgetCommands;

namespace CoachingPlan.ApplicationService
{
    public class BudgetApplicationService : BaseApplicationService, IBudgetApplicationService
    {
        private IBudgetRepository _repository;

        public BudgetApplicationService(IBudgetRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Budget Create(CreateBudgetCommand command)
        {
            var service = new Budget(command.Proposal, command.Price, command.ProposalDate, command.Status, command.SessionPrice, command.IdCoachingProcess);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public Budget Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Budget> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Budget> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Budget GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Budget> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _repository.GetAllByCoachingProcess(idCoachingProcess);
        }
        public Budget Update(UpdateBudgetCommand command)
        {
            var budget = _repository.GetOne(command.Id);
            if (command.Proposal != null)
                budget.ChangeProposal(command.Proposal);
            if (command.Price != 0)
                budget.ChangePrice(command.Price);
            if (command.Status != 0)
                budget.ChangeStatus(command.Status);
            if (command.SessionPrice != 0)
                budget.ChangeSessionPrice(command.SessionPrice);

            _repository.Update(budget);

            if (Commit())
                return budget;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
