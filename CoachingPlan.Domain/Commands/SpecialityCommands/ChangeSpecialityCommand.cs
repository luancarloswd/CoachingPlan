using System;

namespace CoachingPlan.Domain.Commands.SpecialityCommands
{
    public class ChangeSpecialityCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ChangeSpecialityCommand(Guid id,string name, string description = null)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
