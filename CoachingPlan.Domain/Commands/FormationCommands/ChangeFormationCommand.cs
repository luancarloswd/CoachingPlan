using System;

namespace CoachingPlan.Domain.Commands.FormationCommands
{
    public class ChangeFormationCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ChangeFormationCommand(Guid id, string name, string description = null)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
