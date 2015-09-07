using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Evaluation
    {
        #region Ctor
        protected Evaluation(){}
        public Evaluation(float note, Guid idSession, User user, string observation = null)
        {
            this.Id = Guid.NewGuid();
            this.Note = note;
            this.IdSession = idSession;
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
            if (!this.CreateEvaluationScopeIsValid())
                return;
            this.Note = note;
        }
        public void ChangeObservation(string observation)
        {
            this.Observation = observation;
        }
        public void Validate()
        {
            if (!this.CreateEvaluationScopeIsValid())
                return;
        }
        #endregion
    }
}
