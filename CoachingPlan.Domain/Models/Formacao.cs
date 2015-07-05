using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Formacao
    {
        #region Ctor
        protected Formacao(){}
        public Formacao(Formacao formacao)
        {
            this.Id = Guid.NewGuid();
            this.Nome = formacao.Nome;
            this.Descricao = formacao.Descricao;
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual Coach Coach { get; set; }
        #endregion
        #region Methods
        public void ChangeTraining(string nome)
        {
            this.Nome = nome;
        }
        public void ChangeDescription(string descricao)
        {
            this.Descricao = descricao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.InvalidTraining);
            AssertionConcern.AssertArgumentLength(this.Nome, 2, 45, Errors.InvalidTraining);
        }
        #endregion
    }
}
