using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.CoachingProcessCommands
{
    public class UpdateCoachingProcessCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EModeProcess Mode { get; set; }
        public string Observation { get; set; }

        public virtual ICollection<Budget> Budget { get;  set; }
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<ActionPlan> ActionPlan { get;  set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<PerformanceIndicator> PerformaceIndicator { get; set; }
        public virtual ICollection<Coachee> Coachee { get; set; }
        public virtual ICollection<Service> Service { get; set; }

        public UpdateCoachingProcessCommand(Guid id, string name, DateTime startDate, DateTime endDate, EModeProcess mode, ICollection<Coach> coach, ICollection<Coachee> coachee, ICollection<PerformanceIndicator> performanceIndicator, ICollection<Service> service, string observation = null)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Mode = mode;
            this.Coach = coach;
            this.Coachee = coachee;
            this.PerformaceIndicator = performanceIndicator;
            this.Service = service;
            this.Observation = observation;
        }
    }
}
