using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.FilledToolCoacheeCommands
{
    public class UpdateFilledToolCoacheeCommand
    {
        public Guid Id { get; private set; }
        public Guid IdEvaluationTool { get; private set; }
        public Guid IdCoachee { get; private set; }
        public DateTime EvaluationDate { get; private set; }

        public virtual EvaluationTool EvaluationTool { get; private set; }
        public virtual Coachee Coachee { get; private set; }

        public UpdateFilledToolCoacheeCommand(Guid id, DateTime evaluationDate, Guid idEvaluationTool, Guid coachee)
        {
            this.Id = id;
            this.IdCoachee = coachee;
            this.IdEvaluationTool = idEvaluationTool;
            this.EvaluationDate = evaluationDate;
        }
    }
}

