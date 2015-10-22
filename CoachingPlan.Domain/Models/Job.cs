using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Job
    {
        #region Ctor
        protected Job(){}
        public Job(DateTime startDate, DateTime? realizationDate, DateTime verificationDate, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.StartDate = startDate;
            this.RealizationDate = realizationDate;
            this.VerificationDate = verificationDate;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public Nullable<Guid> IdSession { get; private set; }
        public Guid IdMark { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? RealizationDate{ get; private set; }
        public DateTime VerificationDate { get; private set; }
        public string Description { get; private set; }

        public virtual Session Session { get; private set; }
        public virtual Mark Mark { get; private set; }
        #endregion

        #region Methods
        public void ChangeRealizationDate(DateTime? realizationDate)
        {
            this.RealizationDate = realizationDate;
        }
        public void ChangeStartDate(DateTime startDate)
        {
            if (!this.ChangeStartDateScopeIsValid(startDate))
                return;
            this.StartDate = startDate;
        }
        public void ChangeVerifaciontDate(DateTime verificationDate)
        {
            if (!this.ChangeVerificationDateScopeIsValid(verificationDate))
                return;
            this.VerificationDate = verificationDate;
        }
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void Validate()
        {
            if (!this.CreateJobScopeIsValid())
                return;
        }
        #endregion
    }
}
