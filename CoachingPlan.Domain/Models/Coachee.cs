using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Coachee
    {
        #region Ctor
        protected Coachee() { }
        public Coachee(Coachee coachee)
        {
            this.Id = Guid.NewGuid();
            this.Profissao = coachee.Profissao;
            //this.Preenchiment_Ferramenta = new HashSet<Preenchimento_Ferramenta>();
            this.Fragilidade = new HashSet<Fragilidade>();
            this.PontoForte = new HashSet<PontoForte>();
            //this.Processo_coaching = new HashSet<Processo_Coaching>();
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Profissao { get; private set; }

        public virtual Usuario Usuario { get; set; }
        //public virtual ICollection<Preenchimento_Ferramenta> Preenchiment_Ferramenta { get; set; }
        public virtual ICollection<Fragilidade> Fragilidade { get; set; }
        public virtual ICollection<PontoForte> PontoForte { get; set; }
        //public virtual ICollection<Processo_Coaching> Processo_coaching { get; set; }
        #endregion
        #region Methods
        public void ChangeProfession(string profissao)
        {
            this.Profissao = profissao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Profissao, Errors.InvalidProfession);
            AssertionConcern.AssertArgumentLength(this.Profissao, 2, 25, Errors.InvalidProfession);
        }
        #endregion
    }
}
