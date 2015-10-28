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
        public virtual ICollection<FilledToolCoachee> FilledTool { get; set; }
        public virtual ICollection<Weakness> Weakness { get; set; }
        public virtual ICollection<StrongPoint> StrongPoint { get; set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; set; }

        public CreateCoacheeCommand() { }
        public CreateCoacheeCommand(string profession, string idUser, List<Weakness> weakness, List<StrongPoint> strongPoint, List<CoachingProcess> coachingProcess)
        {
            this.Profession = profession;
            this.IdUser = idUser;
            this.Weakness = weakness;
            this.StrongPoint = strongPoint;
            this.CoachingProcess = coachingProcess;
        }
    }
}
