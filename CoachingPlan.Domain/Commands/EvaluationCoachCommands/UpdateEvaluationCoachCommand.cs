using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.EvaluationCoachCommands
{
    public class UpdateEvaluationCoachCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoach { get; private set; }
        public Guid IdSession { get; private set; }
        public int? Evaluation { get; private set; }
        public string Observation { get; private set; }

        public virtual Coach Coach { get; private set; }
        public virtual Session Session { get; private set; }
        public UpdateEvaluationCoachCommand(Guid id, int? evaluation, string observation = null)
        {
            this.Id = id;
            this.Evaluation = evaluation;
            this.Observation = observation;
        }
    }
}
