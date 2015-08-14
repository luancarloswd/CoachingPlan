using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Speciality
    {
        #region Ctor
        protected Speciality(){}
        public Speciality(string name, string description = null)
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

        public virtual Coach Coach { get; set; }
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
            AssertionConcern.AssertArgumentNotNull(this.Name, Errors.InvalidSpecialty);
            AssertionConcern.AssertArgumentLength(this.Name, 2, 45, Errors.InvalidSpecialty);
        }
        #endregion
    }
}
