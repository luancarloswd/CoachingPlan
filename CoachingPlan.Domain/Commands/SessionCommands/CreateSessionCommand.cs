using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.SessionCommands
{
    public class CreateSessionCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoachingProcess { get; private set; }
        public string IdUser { get; private set; }
        public string Theme { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan? EndTime { get; private set; }
        public ESessionClassification Classification { get; private set; }
        public string Observation { get; private set; }

        public virtual User User { get; private set; }
        public virtual ICollection<Job> Job { get; private set; }
        public virtual ICollection<EvaluationCoach> Coach { get; private set; }
        public virtual ICollection<EvaluationCoachee> Coachee { get; private set; }
        public virtual CoachingProcess CoachingProcess { get; private set; }

        public CreateSessionCommand(CoachingProcess coachingProcess, string theme, User user, DateTime date, TimeSpan startTime, TimeSpan? endTime, ESessionClassification classification, string observation, ICollection<Job> job)
        {
            this.Theme = theme;
            this.Date = date;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Classification = classification;
            this.CoachingProcess = coachingProcess;
            this.User = user;
            this.Observation = observation;
            this.Job = job;
        }
    }
}
