using CoachingPlan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Domain.Models
{
    public class Coach
    {
        #region Ctor
        protected Coach(){}
        public Coach(string idUser, ICollection<EvaluationTool> evaluationTool, ICollection<Speciality> speciality, ICollection<Formation> formation, ICollection<CoachingProcess> coachingProcess)
        {
            this.Id = Guid.NewGuid();
            this.EvaluationTool = new HashSet<EvaluationTool>();
            evaluationTool.ToList().ForEach(x => AddEvaluationTool(x));
            this.Formation = new HashSet<Formation>();
            formation.ToList().ForEach(x => AddFormation(x));
            this.Speciality = new HashSet<Speciality>();
            speciality.ToList().ForEach(x => AddSpeciality(x));
            this.CoachingProcess = new HashSet<CoachingProcess>();
            coachingProcess.ToList().ForEach(x => AddCoachingProcess(x));
            this.IdUser = idUser;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public virtual ICollection<EvaluationTool> EvaluationTool { get; private set; }
        public virtual ICollection<Speciality> Speciality { get; private set; }
        public virtual ICollection<Formation> Formation { get; private set; }
        public virtual User User { get; private set; }
        public virtual ICollection<CoachingProcess> CoachingProcess { get; private set; }
        #endregion

        #region Methods
        public void ChangeUser(User user)
        {
            this.User = user;
            this.IdUser = user.Id;
        }
        public void AddCoachingProcess(CoachingProcess coachingProcess)
        {
            this.CoachingProcess.Add(coachingProcess);
        }
        public void RemoveCoachingProcess(CoachingProcess coachingProcess)
        {
            this.CoachingProcess.Remove(coachingProcess);
        }
        public void AddEvaluationTool(EvaluationTool evaluationTool)
        {
            evaluationTool.Validate();
            this.EvaluationTool.Add(evaluationTool);
        }
        public void RemoveEvaluationTool(EvaluationTool evaluationTool)
        {
            this.EvaluationTool.Remove(evaluationTool);
        }
        public void AddFormation(Formation formation)
        {
            formation.Validate();
            this.Formation.Add(formation);
        }
        public void RemoveSpeciality(Formation formation)
        {
            this.Formation.Remove(formation);
        }
        public void AddSpeciality(Speciality Speciality)
        {
            Speciality.Validate();
            this.Speciality.Add(Speciality);
        }
        public void RemoveSpeciality(Speciality Speciality)
        {
            this.Speciality.Remove(Speciality);
        }
        #endregion
    }
}
