using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.PerformanceIndicatorCommands
{
    public class UpdatePerformanceIndicatorCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoachingProcess { get; private set; }
        public string Indicator { get; private set; }

        public UpdatePerformanceIndicatorCommand(Guid id,string indicator)
        {
            this.Id = id;
            this.Indicator = indicator;
        }
    }
}
