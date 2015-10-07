using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Commands.ServiceCommands
{
    public class CreateServiceCommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public float Value { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; private set; }

        public CreateServiceCommand(string name, float value, string description = null)
        {
            this.Name = name;
            this.Value = value;
            this.Description = description;
        }
    }
}
