using CoachingPlan.Domain.Enums;
using System;

namespace CoachingPlan.Domain.Commands.StrongPointCommands
{
    public class CreateStrongPointCommand
    {
        public Guid IdCoachee { get; set; }
        public string Name { get; set; }
        public EClassStrongPoint Class { get; set; }
        public string Description { get; set; }

        public CreateStrongPointCommand(string name, EClassStrongPoint classStrongPoint, Guid idCoachee, string description = null)
        {
            this.IdCoachee = idCoachee;
            this.Name = name;
            this.Class = classStrongPoint;
            this.Description = description;
        }
    }
}
