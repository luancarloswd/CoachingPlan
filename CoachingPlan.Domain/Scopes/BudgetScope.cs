using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class BudgetScope
    {
        public static bool CreateBudgetScopeIsValid(this Budget budget)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(budget.Proposal, Errors.ProposalIsRequired),
                            AssertionConcern.AssertArgumentNotNull(budget.Price, Errors.PriceIsRequired),
                            AssertionConcern.AssertArgumentNotNull(budget.ProposalDate, Errors.DateIsRequired),
                            AssertionConcern.AssertArgumentIsGreaterOrEqualThan(DateTime.Now, budget.ProposalDate, Errors.InvalidDate),
                            AssertionConcern.AssertArgumentNotNull(budget.SessionPrice, Errors.SessionPriceIsRequired)
                );
        }
        public static bool ChangeSessionPriceScopeIsValid(this Budget actionPlan, float sessionPrice)
        {
            return AssertionConcern.IsSatisfiedBy(
                         AssertionConcern.AssertArgumentNotNull(sessionPrice, Errors.SessionPriceIsRequired)
                );
        }
        public static bool ChangeProposalDateScopeIsValid(this Budget actionPlan, DateTime proposalDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                         AssertionConcern.AssertArgumentNotNull(proposalDate, Errors.DateIsRequired),
                         AssertionConcern.AssertArgumentIsGreaterOrEqualThan(DateTime.Now, proposalDate, Errors.InvalidDate)
                );
        }
        public static bool ChangePriceScopeIsValid(this Budget actionPlan, float price)
        {
            return AssertionConcern.IsSatisfiedBy(
                         AssertionConcern.AssertArgumentNotNull(price, Errors.PriceIsRequired)
                );
        }
        public static bool ChangeProposalScopeIsValid(this Budget actionPlan, string proposal)
        {
            return AssertionConcern.IsSatisfiedBy(
                          AssertionConcern.AssertArgumentNotNull(proposal, Errors.ProposalIsRequired)
                );
        }
    }
}
