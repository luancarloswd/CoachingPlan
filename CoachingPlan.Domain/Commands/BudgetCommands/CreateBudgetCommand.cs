using CoachingPlan.Domain.Enums;
using System;

namespace CoachingPlan.Domain.Commands.BudgetCommands
{
    public class CreateBudgetCommand
    {
        public Guid Id { get; set; }
        public Guid IdCoachingProcess { get; set; }
        public string Proposal { get; set; }
        public float Price { get; set; }
        public DateTime ProposalDate { get; set; }
        public float SessionPrice { get; set; }
        public EBudgetStatus Status { get; set; }

        public CreateBudgetCommand(string proposal, float price, DateTime proposalDate, EBudgetStatus status, float sessionPrice, Guid idCoachingProcess)
        {
            this.Proposal = proposal;
            this.Price = price;
            this.Status = status;
            this.ProposalDate = proposalDate;
            this.SessionPrice = sessionPrice;
            this.IdCoachingProcess = idCoachingProcess;
        }
    }
}
