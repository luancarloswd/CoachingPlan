using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.ServiceCommands
{
    public class UpdateServiceCommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public float Value { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; private set; }

        public UpdateServiceCommand(Guid id, string name, float value, string description = null)
        {
            this.Id = id;
            this.Name = name;
            this.Value = value;
            this.Description = description;
        }
    }
}
