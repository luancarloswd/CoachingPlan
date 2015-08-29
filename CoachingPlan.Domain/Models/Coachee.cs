using CoachingPlan.Domain.Enums;
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
        public Coachee(string profession, User user)
        {
            this.Id = Guid.NewGuid();
            this.Profession = profession;
            this.User = user;
            this.IdUser = user.Id;
            this.FilledTool = new HashSet<FilledTool>();
            this.Weakness = new HashSet<Weakness>();
            this.StrongPoint = new HashSet<StrongPoint>();
            this.CoachingProcess = new HashSet<CoachingProcess>();
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public string Profession { get; private set; }

        public virtual User User { get; set; }
        public virtual ICollection<FilledTool> FilledTool { get; set; }
        public virtual ICollection<Weakness> Weakness { get; set; }
        public virtual ICollection<StrongPoint> StrongPoint { get; set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; set; }
        #endregion

        #region Methods
        public void ChangeUser(User user)
        {
            this.User = user;
            this.IdUser = user.Id;
        }
        public void AddWeakness(string name, Coachee coachee, string description = null)
        {
            Weakness weakness = new Weakness(name, coachee, description);
            weakness.Validate();
            this.Weakness.Add(weakness);
        }    
        public void RemoveWeakness(Weakness weakness)
        {
            this.Weakness.Remove(weakness);
        }
        public void AddStrongPoint(string name, EClassStrongPoint classStrongPoint, Coachee coachee, string description = null)
        {
            StrongPoint strongPoint = new StrongPoint(name, classStrongPoint, coachee, description);
            strongPoint.Validate();
            this.StrongPoint.Add(strongPoint);
        }
        public void RemoveStrongPoint(StrongPoint strongPoint)
        {
            this.StrongPoint.Remove(strongPoint);
        }
        public void ChangeProfession(string profession)
        {
            this.Profession = profession;
            this.Validate();
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Profession, Errors.InvalidProfession);
            AssertionConcern.AssertArgumentLength(this.Profession, 2, 25, Errors.InvalidProfession);
        }
        #endregion
    }
}
