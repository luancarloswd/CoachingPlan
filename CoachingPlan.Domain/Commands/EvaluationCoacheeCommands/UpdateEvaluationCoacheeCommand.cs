using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.EvaluationCoacheeCommands
{
    public class UpdateEvaluationCoacheeCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoachee { get; private set; }
        public Guid IdSession { get; private set; }
        public int? Evaluation { get; private set; }
        public string Observation { get; private set; }

        public virtual Coachee Coachee { get; private set; }
        public virtual Session Session { get; private set; }
        public UpdateEvaluationCoacheeCommand(Guid id, int? evaluation, string observation = null)
        {
            this.Id = id;
            this.Evaluation = evaluation;
            this.Observation = observation;
        }
    }
}
