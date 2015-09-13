using System;

namespace CoachingPlan.Domain.Commands.FormationCommands
{
    public class CreateFormationCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid IdCoach { get; set; }
        public CreateFormationCommand(string name, Guid idCoach, string description = null)
        {
            this.Name = name;
            this.IdCoach = idCoach;
            this.Description = description;
        }
    }
}
