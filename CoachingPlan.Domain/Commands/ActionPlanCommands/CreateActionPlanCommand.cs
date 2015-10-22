using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.ActionPlanCommands
{
    public class CreateActionPlanCommand
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; private set; }
        public virtual ICollection<Objective> Objective { get; private set; }

        public CreateActionPlanCommand(ICollection<Objective> objective, CoachingProcess coachingProcess, string Description = null)
        {
            this.CoachingProcess = new HashSet<CoachingProcess>();
            this.CoachingProcess.Add(coachingProcess);
            this.Objective = objective;
            this.Description = Description;
        }
    }
}
