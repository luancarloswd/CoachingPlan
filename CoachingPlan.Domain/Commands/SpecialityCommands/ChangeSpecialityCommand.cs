using System;

namespace CoachingPlan.Domain.Commands.SpecialityCommands
{
    public class ChangeSpecialityCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ChangeSpecialityCommand(string name, Guid idCoach, string description = null)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
