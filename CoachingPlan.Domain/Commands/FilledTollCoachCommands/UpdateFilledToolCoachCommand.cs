using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.FilledToolCoachCommands
{
    public class UpdateFilledToolCoachCommand
    {
        public Guid Id { get; private set; }
        public Guid IdEvaluationTool { get; private set; }
        public Guid IdCoach { get; private set; }
        public DateTime EvaluationDate { get; private set; }

        public virtual EvaluationTool EvaluationTool { get; private set; }
        public virtual Coachee Coachee { get; private set; }

        public UpdateFilledToolCoachCommand(Guid id, DateTime evaluationDate, Guid idEvaluationTool, Guid coach)
        {
            this.Id = id;
            this.IdCoach = coach;
            this.IdEvaluationTool = idEvaluationTool;
            this.EvaluationDate = evaluationDate;
        }
    }
}

