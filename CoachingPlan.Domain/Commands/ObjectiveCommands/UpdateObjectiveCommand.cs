using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.ObjectiveCommands
{
    public class UpdateObjectiveCommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Term { get; private set; }
        public Guid IdActionPlan { get; set; }

        public virtual ActionPlan ActionPlan { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }

        public UpdateObjectiveCommand(Guid id, ICollection<Mark> mark, DateTime term, string description = null)
        {
            this.Term = term;
            this.Id = id;
            this.Mark = mark;
            this.Description = description;

        }
    }
}
