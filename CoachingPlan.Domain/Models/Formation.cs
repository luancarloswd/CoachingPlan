using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Formation
    {
        #region Ctor
        protected Formation(){}
        public Formation(string name, Guid idCoach, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.IdCoach = idCoach;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid IdCoach { get; private set; }

        public virtual Coach Coach { get; private set; }
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
            if (!this.CreateFormationScopeIsValid())
                return;
        }
        #endregion
    }
}
