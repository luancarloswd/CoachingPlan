using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.EvaluationToolCommands
{
    public class UpdateEvaluationToolCommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public ETypeEvaluationTool Type { get; private set; }

        public virtual ICollection<Coach> Coach { get; private set; }
        public virtual ICollection<Question> Question { get; private set; }
        public virtual ICollection<FilledToolCoach> FilledToolCoach { get; private set; }

        public virtual ICollection<FilledToolCoachee> FilledToolCoachee { get; private set; }
        public UpdateEvaluationToolCommand(Guid id, string name, ETypeEvaluationTool type, ICollection<Question> question)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;  
            this.Question = question;
        }
    }
}
