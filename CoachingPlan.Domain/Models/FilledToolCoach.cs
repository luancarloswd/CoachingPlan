using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class FilledToolCoach
    {
        #region Ctor
        protected FilledToolCoach(){}
        public FilledToolCoach(DateTime evaluationDate, Guid idEvaluationTool, Guid idCoachingProcess, Guid idCoach)
        {
            this.Id = Guid.NewGuid();
            this.IdCoach = idCoach;
            this.IdCoachingProcess = idCoachingProcess;
            this.IdEvaluationTool = idEvaluationTool;
            this.EvaluationDate = evaluationDate;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public Guid IdEvaluationTool { get; private set; }
        public Guid IdCoach { get; private set; }
        public Guid IdCoachingProcess { get; private set; }
        public DateTime EvaluationDate { get; private set; }

        public virtual EvaluationTool EvaluationTool { get; private set; }
        public virtual Coach Coach { get; private set; }
        public virtual CoachingProcess CoachingProcess { get; private set; }
        #endregion

        #region Methods
        public void ChangeEvaluationDate(DateTime evaluationDate)
        {
            if (!this.ChangeEvaluationDateScopeIsValid(evaluationDate))
                return;
            this.EvaluationDate = evaluationDate;
        }
        public void Validate()
        {
            if (!this.CreateFilledToolScopeIsValid())
                return;
        }
        #endregion
    }
}
