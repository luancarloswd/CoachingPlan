using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.JobCommands
{
    public class CreateJobCommand
    {
        public Guid Id { get; private set; }
        public Guid IdSession { get; private set; }
        public Guid IdMark { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? RealizationDate { get; private set; }
        public DateTime VerificationDate { get; private set; }
        public string Description { get; private set; }

        public virtual Session Session { get; private set; }
        public virtual Mark Mark { get; private set; }

        public CreateJobCommand(DateTime startDate, DateTime VerificationDate, DateTime? realizationDate, string description = null)
        {
            this.StartDate = startDate;
            this.VerificationDate = VerificationDate;
            this.RealizationDate = realizationDate;
            this.Description = description;
        }
    }
}
