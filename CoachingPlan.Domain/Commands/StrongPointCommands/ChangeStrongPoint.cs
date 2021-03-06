﻿using CoachingPlan.Domain.Enums;
using System;

namespace CoachingPlan.Domain.Commands.StrongPointCommands
{
    public class ChangeStrongPointCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EClassStrongPoint Class { get; set; }
        public string Description { get; set; }

        public ChangeStrongPointCommand(Guid id, string name, EClassStrongPoint classStrongPoint, string description = null)
        {
            this.Id = id;
            this.Name = name;
            this.Class = classStrongPoint;
            this.Description = description;
        }
    }
}
