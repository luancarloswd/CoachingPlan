using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.CoacheeCommands
{
    public class UpdateCoacheeCommand
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public string Profession { get; set; }
        public virtual ICollection<FilledTool> FilledTool { get; set; }
        public virtual ICollection<Weakness> Weakness { get; set; }
        public virtual ICollection<StrongPoint> StrongPoint { get; set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; set; }
        public UpdateCoacheeCommand(){}
        public UpdateCoacheeCommand(Guid id,string profession, string idUser, ICollection<Weakness> weakness, ICollection<StrongPoint> strongPoint, ICollection<CoachingProcess> coachingProcess)
        {
            this.Id = id;
            this.Profession = profession;
            this.IdUser = idUser;
            this.Weakness = weakness;
            this.StrongPoint = strongPoint;
            this.CoachingProcess = coachingProcess;
        }
    }
}
