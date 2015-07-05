using CoachingPlan.Domain.Enums;
using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class PontoForte
    {
        #region Ctor
        protected PontoForte() {}
        public PontoForte(PontoForte pontoforte)
        {
            this.Id = Guid.NewGuid();
            this.Nome = pontoforte.Nome;
            this.Classe = pontoforte.Classe;
            this.Descricao = pontoforte.Descricao;
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public EClassePontoForte.Classe Classe { get; private set; }
        public string Descricao { get; private set; }

        public virtual Coachee Coachee { get; set; }
        #endregion
        #region Methods
        public void ChangeStrongPoing(string nome)
        {
            this.Nome = nome;
        }
        public void ChangeClass(EClassePontoForte.Classe classe)
        {
            this.Classe = classe;
        }
        public void ChangeDescription(string descricao)
        {
            this.Descricao = descricao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.InvalidStrongPoint);
            AssertionConcern.AssertArgumentLength(this.Nome, 2, 50, Errors.InvalidStrongPoint);
            AssertionConcern.AssertArgumentNotNull(this.Classe, Errors.InvalidClassStrongPoint);
        }
        #endregion
    }
}
