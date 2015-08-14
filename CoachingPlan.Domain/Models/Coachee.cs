using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Coachee
    {
        #region Ctor
        protected Coachee() { }
        public Coachee(string profession)
        {
            this.Id = Guid.NewGuid();
            this.Profession = profession;
            this.FilledTool = new HashSet<FilledTool>();
            this.Weakness = new HashSet<Speciality>();
            this.StrongPoint = new HashSet<StrongPoint>();
            this.CoachingProcess = new HashSet<CoachingProcess>();
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Profession { get; private set; }

        public virtual User User { get; set; }
        public virtual ICollection<FilledTool> FilledTool { get; set; }
        public virtual ICollection<Speciality> Weakness { get; set; }
        public virtual ICollection<StrongPoint> StrongPoint { get; set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; set; }
        #endregion
        #region Methods
        public void ChangeProfession(string profession)
        {
            this.Profession = profession;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Profession, Errors.InvalidProfession);
            AssertionConcern.AssertArgumentLength(this.Profession, 2, 25, Errors.InvalidProfession);
        }
        #endregion
    }
}
