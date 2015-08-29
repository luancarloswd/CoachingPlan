using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Job
    {
        #region Ctor
        protected Job(){}
        public Job(DateTime startDate, DateTime? realizationDate, DateTime verificationDate, Session session, Mark mark, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.StartDate = startDate;
            this.RealizationDate = realizationDate;
            this.VerificationDate = verificationDate;
            this.Session = session;
            this.IdSession = session.Id;
            this.Mark = mark;
            this.IdMark = mark.Id;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public Guid IdSession { get; private set; }
        public Guid IdMark { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? RealizationDate{ get; private set; }
        public DateTime VerificationDate { get; private set; }
        public string Description { get; private set; }

        public virtual Session Session { get; private set; }
        public virtual Mark Mark { get; private set; }
        #endregion

        #region Methods
        public void ChageRealizationDate(DateTime realizationDate)
        {
            this.RealizationDate = realizationDate;
            this.Validate();
        }
        public void ChangeVerifaciontDate(DateTime verificationDate)
        {
            this.VerificationDate = verificationDate;
            this.Validate();
        }
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.StartDate, Errors.DataIsRequired);
            AssertionConcern.AssertArgumentNotNull(this.VerificationDate, Errors.VerificationDataIsRequired);
        }
        #endregion
    }
}
