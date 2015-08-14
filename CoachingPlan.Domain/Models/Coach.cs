using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Coach
    {
        #region Ctor
        public Coach()
        {
            this.Id = Guid.NewGuid();
            this.EvaluationTool = new HashSet<EvaluationTool>();
            this.Speciality = new HashSet<Speciality>();
            this.Formation = new HashSet<Formation>();
            this.CoachingProcess = new HashSet<CoachingProcess>();
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public virtual ICollection<EvaluationTool> EvaluationTool { get; private set; }
        public virtual ICollection<Speciality> Speciality { get; private set; }
        public virtual ICollection<Formation> Formation { get; private set; }
        public virtual User User { get; private set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; private set; }
        #endregion

        #region Methods
        #endregion
    }
}
