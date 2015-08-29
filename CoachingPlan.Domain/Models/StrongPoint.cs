using CoachingPlan.Domain.Enums;
using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class StrongPoint
    {
        #region Ctor
        protected StrongPoint() {}
        public StrongPoint(string name, EClassStrongPoint classStrongPoint, Coachee coachee, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.Coachee = coachee;
            this.IdCoachee = coachee.Id;
            this.Name = name;
            this.Class = classStrongPoint;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public Guid IdCoachee { get; private set; }
        public string Name { get; private set; }
        public EClassStrongPoint Class { get; private set; }
        public string Description { get; private set; }

        public virtual Coachee Coachee { get; set; }
        #endregion

        #region Methods
        public void ChangeName(string name)
        {
            this.Name = name;
            this.Validate();
        }
        public void ChangeClass(EClassStrongPoint classStrongPoint)
        {
            this.Class = classStrongPoint;
            this.Validate();
        }
        public void ChangeDescription(string descricao)
        {
            this.Description = descricao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Name, Errors.InvalidStrongPoint);
            AssertionConcern.AssertArgumentLength(this.Name, 2, 50, Errors.InvalidStrongPoint);
            AssertionConcern.AssertArgumentNotNull(this.Class, Errors.InvalidClassStrongPoint);
        }
        #endregion
    }
}
