using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Weakness
    {
        #region Ctor
        protected Weakness(){}
        public Weakness(string name, Coachee coachee, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Coachee = coachee;
            this.IdCoachee = coachee.Id;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public Guid IdCoachee { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual Coachee Coachee { get; set; }
        #endregion

        #region Methods
        public void ChangeName(string name)
        {
            this.Name = name;
        }
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Name, Errors.InvalidWeakness);
            AssertionConcern.AssertArgumentLength(this.Name, 2, 30, Errors.InvalidWeakness);
        }
        #endregion
    }
}
