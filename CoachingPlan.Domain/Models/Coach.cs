using CoachingPlan.Domain.Enums;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Coach
    {
        #region Ctor
        protected Coach(){}
        public Coach(User user)
        {
            this.Id = Guid.NewGuid();
            this.EvaluationTool = new HashSet<EvaluationTool>();
            this.Speciality = new HashSet<Speciality>();
            this.Formation = new HashSet<Formation>();
            this.CoachingProcess = new HashSet<CoachingProcess>();
            this.User = user;
            this.IdUser = user.Id;
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
        public void AddEvaluationTool(string name, ETypeEvaluationTool type, Coach coach)
        {
            EvaluationTool evaluationTool = new EvaluationTool(name, type, coach);
            evaluationTool.Validate();
            this.EvaluationTool.Add(evaluationTool  );
        }
        public void RemoveEvaluationTool(EvaluationTool evaluationTool)
        {
            this.EvaluationTool.Remove(evaluationTool);
        }
        public void AddSpeciality(string name, Coach coach, string description = null)
        {
            Speciality speciality = new Speciality(name, coach, description);
            speciality.Validate();
            this.Speciality.Add(speciality);
        }
        public void RemoveSpeciality(Speciality speciality)
        {
            this.Speciality.Remove(speciality);
        }
        public void AddFormation(string name, Coach coach, string description = null)
        {
            Formation formation = new Formation(name, coach, description);
            formation.Validate();
            this.Formation.Add(formation);
        }
        public void RemoveFormation(Formation formation)
        {
            this.Formation.Remove(formation);
        }
        #endregion
    }
}
