using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Fragilidade
    {
        #region Ctor
        public Fragilidade(){}
        public Fragilidade(Fragilidade fragilidade)
        {
            this.Id = Guid.NewGuid();
            this.Nome= fragilidade.Nome;
            this.Descricao = fragilidade.Descricao;
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual Coachee Coachee { get; set; }
        #endregion
        #region Methods
        public void ChangeWeakness(string nome)
        {
            this.Nome = nome;
        }
        public void ChangeDescription(string descricao)
        {
            this.Descricao = descricao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.InvalidWeakness);
            AssertionConcern.AssertArgumentLength(this.Nome, 2, 30, Errors.InvalidWeakness);
        }
        #endregion
    }
}
