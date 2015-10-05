using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Weakness
    {
        #region Ctor
        protected Weakness(){}
        public Weakness(string name, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
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
            if (!this.ChangeNameScopeIsValid(name))
                return;
            this.Name = name;
        }
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void Validate()
        {
            if (!this.CreateWeaknessScopeIsValid())
                return;
        }
        #endregion
    }
}
