using System;

namespace CoachingPlan.Domain.Commands.WeaknessCommands
{
    public class CreateWeaknessCommand
    {
        public Guid IdCoachee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateWeaknessCommand(string name, Guid idCoachee, string description = null)
        {
            this.IdCoachee = idCoachee;
            this.Name = name;
            this.Description = description;
        }
    }
}
