using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.CoacheeCommands
{
    public class CreateCoacheeCommand
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public string Profession { get; set; }
        public virtual ICollection<FilledTool> FilledTool { get; set; }
        public virtual ICollection<Weakness> Weakness { get; set; }
        public virtual ICollection<StrongPoint> StrongPoint { get; set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; set; }

        public CreateCoacheeCommand(string profession, string idUser, ICollection<FilledTool> filledTool, ICollection<Weakness> weakness, ICollection<StrongPoint> strongPoint, ICollection<CoachingProcess> coachingProcess)
        {
            this.Profession = profession;
            this.IdUser = idUser;
            this.FilledTool = filledTool;
            this.Weakness = weakness;
            this.StrongPoint = strongPoint;
            this.CoachingProcess = coachingProcess;
        }
    }
}
