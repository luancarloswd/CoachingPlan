using CoachingPlan.Domain.Enums;
using System;

namespace CoachingPlan.Domain.Commands.BudgetCommands
{
    public class UpdateBudgetCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoachingProcess { get; private set; }
        public string Proposal { get; private set; }
        public float Price { get; private set; }
        public DateTime ProposalDate { get; private set; }
        public float SessionPrice { get; private set; }
        public EBudgetStatus Status { get; private set; }

        public UpdateBudgetCommand(Guid id, string proposal, float price, DateTime proposalDate, EBudgetStatus status, float sessionPrice, Guid idCoachingProcess)
        {
            this.Id = id;
            this.Proposal = proposal;
            this.Price = price;
            this.Status = status;
            this.ProposalDate = proposalDate;
            this.SessionPrice = sessionPrice;
            this.IdCoachingProcess = idCoachingProcess;
        }
    }
}

