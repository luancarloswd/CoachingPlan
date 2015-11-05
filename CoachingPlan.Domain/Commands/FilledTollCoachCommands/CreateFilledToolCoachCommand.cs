using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.FilledToolCoachCommands
{
    public class CreateFilledToolCoachCommand
    {
        public Guid Id { get; set; }
        public Guid IdEvaluationTool { get; set; }
        public Guid IdCoach { get; set; }
        public Nullable<DateTime> EvaluationDate { get; set; }
        public Guid idCoachingProcess { get; set; }

        public virtual EvaluationTool EvaluationTool { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual CoachingProcess CoachingProcess {get; set;}

        public CreateFilledToolCoachCommand(DateTime? evaluationDate, Guid idEvaluationTool, Guid idCoachingProcess, Guid idCoach)
        {
            this.IdCoach = idCoach;
            this.IdEvaluationTool = idEvaluationTool;
            this.EvaluationDate = evaluationDate;
            this.idCoachingProcess = idCoachingProcess;
        }

    }
}
