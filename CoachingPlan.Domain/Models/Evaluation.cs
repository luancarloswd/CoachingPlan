using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Evaluation
    {
        #region Ctor
        protected Evaluation(){}
        public Evaluation(float note, Session session, User user, string observation = null)
        {
            this.Id = Guid.NewGuid();
            this.Note = note;
            this.Session = session;
            this.IdSession = session.Id;
            this.User = user;
            this.IdUser = user.Id;
            this.Observation = observation;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public float Note { get; private set; }
        public string Observation { get; private set; }
        public Guid IdSession { get; private set; }
        public string IdUser { get; private set; }

        public virtual Session Session { get; private set; }
        public virtual User User { get; private set; }
        #endregion

        #region Methods
        public void ChangeSession(Session session)
        {
            session.Validate();
            this.Session = session;
            this.IdSession = session.Id;
        }
        public void ChangeUser(User user)
        {
            this.User = user;
            this.IdUser = user.Id;
        }
        public void ChangeNote(float note)
        {
            this.Note = note;
            this.Validate();
        }
        public void ChangeObservation(string observation)
        {
            this.Observation = observation;
            this.Validate();
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Note, Errors.NoteIsRequired);
        }
        #endregion
    }
}
