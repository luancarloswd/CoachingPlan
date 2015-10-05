using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Domain.Models
{
    public class Coachee
    {
        #region Ctor
        protected Coachee() { }
        public Coachee(string profession, string idUser, ICollection<Weakness> weakness, ICollection<StrongPoint> strongPoint, ICollection<CoachingProcess> coachingProcess)
        {
            this.Id = Guid.NewGuid();
            this.Profession = profession;
            this.IdUser = idUser;
            this.FilledTool = new HashSet<FilledTool>();
            this.Weakness = new HashSet<Weakness>();
            if (weakness != null)
                weakness.ToList().ForEach(x => AddWeakness(x));
            this.StrongPoint = new HashSet<StrongPoint>();
            if (strongPoint != null)
                strongPoint.ToList().ForEach(x => AddStrongPoint(x));
            this.CoachingProcess = new HashSet<CoachingProcess>();
            if (coachingProcess != null)
                coachingProcess.ToList().ForEach(x => AddCoachingProcess(x));
            this.Session = new HashSet<Session>();
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
        public virtual ICollection<Session> Session { get; set; }
        #endregion

        #region Methods
        public void ChangeUser(User user)
        {
            this.User = user;
            this.IdUser = user.Id;
        }
        public void AddCoachingProcess(CoachingProcess coachingProcess)
        {
            coachingProcess.Validate();
            this.CoachingProcess.Add(coachingProcess);
        }
        public void RemoveCoachingProcess(CoachingProcess coachingProcess)
        {
            this.CoachingProcess.Remove(coachingProcess);
        }
        public void AddFilledTool(FilledTool filedTool)
        {
            filedTool.Validate();
            this.FilledTool.Add(filedTool);
        }
        public void RemoveFilledTool(FilledTool filledTool)
        {
            this.FilledTool.Remove(filledTool);
        }
        public void AddWeakness(Weakness weakness)
        {
            weakness.Validate();
            this.Weakness.Add(weakness);
        }    
        public void RemoveWeakness(Weakness weakness)
        {
            this.Weakness.Remove(weakness);
        }
        public void AddStrongPoint(StrongPoint strongPoint)
        {
            strongPoint.Validate();
            this.StrongPoint.Add(strongPoint);
        }
        public void RemoveStrongPoint(StrongPoint strongPoint)
        {
            this.StrongPoint.Remove(strongPoint);
        }
        public void ChangeProfession(string profession)
        {
            if (!this.ChangeProfessionScopeIsValid(profession))
                return;
            this.Profession = profession;
        }
        public void Validate()
        {
            if (!this.CreateCoacheeScopeIsValid())
                return;
        }
        #endregion
    }
}
