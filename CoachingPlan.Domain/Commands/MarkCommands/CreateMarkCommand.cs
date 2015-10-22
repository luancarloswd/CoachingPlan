using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.MarkCommands
{
    public class CreateMarkCommand
    {
        public Guid Id { get; private set; }
        public Guid IdObjective { get; private set; }
        public DateTime Term { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<Job> Job { get; private set; }
        public virtual Objective Objective { get; private set; }


        public CreateMarkCommand(ICollection<Job> job, DateTime term, string description = null)
        {
            this.Term = term;
            this.Job = job;
            this.Description = description;
        }
    }
}
