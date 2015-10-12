using System;

namespace CoachingPlan.Domain.Commands.PerformanceIndicatorCommands
{
    public class CreatePerformanceIndicatorCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoachingProcess { get; private set; }
        public string Indicator { get; private set; }

        public CreatePerformanceIndicatorCommand(Guid idCoachingProcess, string indicator)
        {
            this.IdCoachingProcess = IdCoachingProcess;
            this.Indicator = indicator;
        }
    }
}
