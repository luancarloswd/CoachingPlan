using System;

namespace CoachingPlan.Domain.Models
{
    public class EvaluationCoach
    {
        #region Ctor
        private EvaluationCoach(){}
        public EvaluationCoach(Guid coach, Guid session, int? evaluation, string observation = null)
        {
            this.Id = Guid.NewGuid();
            this.IdCoach = coach;
            this.IdSession = session;
            this.Evaluation = evaluation;
            this.Observation = observation;
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public Guid IdCoach { get; private set; }
        public Guid IdSession { get; private set; }
        public int? Evaluation { get; private set; }
        public string Observation { get; private set; }

        public virtual Coach Coach { get; private set; }
        public virtual Session Session { get; private set; }
        #endregion

        #region Methods
        public void ChangeEvaluation(int? evaluation)
        {
            this.Evaluation = evaluation;
        }
        public void ChangeObservation(string observation)
        {
            this.Observation = observation;
        }
        #endregion
    }
}
