using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.CoachCommands
{
    public class UpdateCoachCommand
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public virtual ICollection<EvaluationTool> EvaluationTool { get; set; }
        public virtual ICollection<Speciality> Speciality { get; set; }
        public virtual ICollection<Formation> Formation { get; set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; set; }

        public UpdateCoachCommand(Guid id, string idUser, ICollection<EvaluationTool> evaluationTool, ICollection<Formation> formation, ICollection<Speciality> speciality, ICollection<CoachingProcess> coachingProcess)
        {
            this.Id = id;
            this.EvaluationTool = evaluationTool;
            this.Speciality = speciality;
            this.Formation = formation;
            this.CoachingProcess = coachingProcess;
            this.IdUser = idUser;
        }
    }
}
