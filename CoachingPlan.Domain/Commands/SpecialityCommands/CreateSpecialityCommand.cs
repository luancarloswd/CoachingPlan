using System;

namespace CoachingPlan.Domain.Commands.SpecialityCommands
{
    public class CreateSpecialityCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid IdCoach { get; set; }
        public CreateSpecialityCommand(string name, Guid idCoach, string description = null)
        {
            this.Name = name;
            this.IdCoach = IdCoach;
            this.Description = description;
        }
    }
}
