using CoachingPlan.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Domain.Models
{
    public class Objective
    {
        #region Ctor
        protected Objective(){}
        public Objective(string description, Guid idActionPlan, DateTime term, ICollection<Mark> mark)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
            this.Term = term;
            this.IdActionPlan = idActionPlan;
            this.Mark = new HashSet<Mark>();
            mark.ToList().ForEach(x => AddMark(x));
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
        public void AddMark(Mark mark)
        {
            mark.Validate();
            this.Mark.Add(mark);
        }
        public void RemoveMark(Mark mark)
        {
            this.Mark.Remove(mark);
        }
        public void ChangeDescription(string description)
        {
            if (!this.ChangeDescriptionScopeIsValid(description))
                return;
            this.Description = description;
        }
        public void ChangeTerm(DateTime term)
        {
            if (!this.ChangeTermGoalScopeIsValid(term))
                return;
            this.Term = term;
        }
        public void Validate()
        {
            if (!this.CreateObjectiveScopeIsValid())
                return;
        }
        #endregion
    }
}
