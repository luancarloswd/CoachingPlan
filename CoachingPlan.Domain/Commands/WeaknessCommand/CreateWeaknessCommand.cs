using System;

namespace CoachingPlan.Domain.Commands.WeaknessCommand
{
    public class CreateWeaknessCommand
    {
        public Guid IdCoachee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CreateWeaknessCommand(string name, Guid idCoachee, string description = null)
        {
            this.Name = name;
            this.IdCoachee = idCoachee;
            this.Description = description;
        }
    }
}
