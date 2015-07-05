using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Especialidade
    {
        #region Ctor
        protected Especialidade(){}
        public Especialidade(Especialidade especialidade)
        {
            this.Id = Guid.NewGuid();
            this.Nome = especialidade.Nome;
            this.Descricao = especialidade.Descricao;
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual Coach Coach { get; set; }
        #endregion
        #region Methods
        public void ChangeSpecialty(string nome)
        {
            this.Nome = Nome;
        }
        public void ChangeDescription(string descricao)
        {
            this.Descricao = descricao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.InvalidSpecialty);
            AssertionConcern.AssertArgumentLength(this.Nome, 2, 45, Errors.InvalidSpecialty);
        }
        #endregion
    }
}
