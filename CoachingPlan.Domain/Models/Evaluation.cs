using System;

namespace CoachingPlan.Domain.Models
{
    public class Evaluation
    {
        #region Ctor
        protected Evaluation(){}
        public Evaluation(float note, string observation = null)
        {
            this.Id = Guid.NewGuid();
            this.Note = note;
            this.Observation = observation;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public float Note { get; private set; }
        public string Observation { get; private set; }
        public int SessionId { get; private set; }
        public string UserId { get; private set; }

        public virtual Session Session { get; private set; }
        public virtual User User { get; private set; }
        #endregion

        #region Methods
        #endregion
    }
}
