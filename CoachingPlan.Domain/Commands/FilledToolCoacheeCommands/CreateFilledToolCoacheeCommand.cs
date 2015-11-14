using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.FilledToolCoacheeCommands
{
    public class CreateFilledToolCoacheeCommand
    {
        public Guid Id { get; set; }
        public Guid IdEvaluationTool { get; set; }
        public Guid IdCoachee { get; set; }
        public DateTime EvaluationDate { get; set; }
        public Guid IdCoachingProcess { get; set; }

        public virtual CoachingProcess CoachingProcess { get; set;}
        public virtual EvaluationTool EvaluationTool { get; set; }
        public virtual Coachee Coachee { get; set; }

        public CreateFilledToolCoacheeCommand(DateTime evaluationDate, Guid idEvaluationTool,Guid idCoachingProcess, Guid idCoachee)
        {
            this.IdCoachee = idCoachee;
            this.IdCoachingProcess = idCoachingProcess;
            this.IdEvaluationTool = idEvaluationTool;
            this.EvaluationDate = evaluationDate;
        }

    }
}
