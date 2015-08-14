using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Objective
    {
        #region Ctor
        protected Objective(){}
        public Objective(string description)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
            this.Mark = new HashSet<Mark>();
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid IdActionPlan { get; set; }

        public virtual ActionPlan ActionPlan { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
