using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.EvaluationCoacheeCommands
{
    public class CreateEvaluationCoacheeCommand
    {
        public Guid Id { get; private set; }
        public Guid IdCoachee { get; private set; }
        public Guid IdSession { get; private set; }
        public int? Evaluation { get; private set; }
        public string Observation { get; private set; }

        public virtual Coachee Coachee { get; private set; }
        public virtual Session Session { get; private set; }
        public CreateEvaluationCoacheeCommand(Guid coachee, Guid session, int? evaluation, string observation = null)
        {
            this.IdCoachee = coachee;
            this.IdSession = session;
            this.Evaluation = evaluation;
            this.Observation = observation;
        }
    }
}
