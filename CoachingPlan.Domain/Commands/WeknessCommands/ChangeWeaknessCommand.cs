using System;

namespace CoachingPlan.Domain.Commands.WeaknessCommands
{
    public class ChangeWeaknessCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ChangeWeaknessCommand(Guid id,string name, string description = null)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
