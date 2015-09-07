﻿using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class StrongPoint
    {
        #region Ctor
        protected StrongPoint() {}
        public StrongPoint(string name, EClassStrongPoint classStrongPoint, Guid idCoachee, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.IdCoachee = idCoachee;
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
            if (!this.ChangeNameScopeIsValid(name))
                return;
            this.Name = name;
        }
        public void ChangeClass(EClassStrongPoint classStrongPoint)
        {
            if (!this.ChangeClassScopeIsValid(classStrongPoint))
                return;
            this.Class = classStrongPoint;
        }
        public void ChangeDescription(string descricao)
        {
            this.Description = descricao;
        }
        public void Validate()
        {
            if (!this.CreateStrongPointScopeIsValid())
                return;
        }
        #endregion
    }
}
