using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Formation
    {
        #region Ctor
        protected Formation(){}
        public Formation(string name, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual Coach Coach { get; private set; }
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
            AssertionConcern.AssertArgumentNotNull(this.Name, Errors.InvalidTraining);
            AssertionConcern.AssertArgumentLength(this.Name, 2, 45, Errors.InvalidTraining);
        }
        #endregion
    }
}
