using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Objective
    {
        #region Ctor
        protected Objective(){}
        public Objective(string description, ActionPlan actionPlan, DateTime term)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
            this.Term = term;
            this.ActionPlan = actionPlan;
            this.IdActionPlan = actionPlan.Id;
            this.Mark = new HashSet<Mark>();
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Term { get; private set; }
        public Guid IdActionPlan { get; set; }

        public virtual ActionPlan ActionPlan { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        #endregion

        #region Methods
        public void AddMark(DateTime term, Objective objective, string description)
        {
            Mark mark = new Mark(term, objective, description);
            mark.Validate();
            this.Mark.Add(mark);
        }
        public void RemoveMark(Mark mark)
        {
            this.Mark.Remove(mark);
        }
        public void ChangeDescription(string description)
        {
            this.Description = description;
            this.Validate();
        }
        public void ChangeTerm(DateTime term)
        {
            this.Term = term;
            this.Validate();
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Description, Errors.InvalidDescription);
            AssertionConcern.AssertArgumentNotNull(this.Term, Errors.TermGoalIsRequired);
        }
        #endregion
    }
}
