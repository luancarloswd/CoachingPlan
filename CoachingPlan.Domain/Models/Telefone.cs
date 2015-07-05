using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Telefone
    {
        #region Ctor
        protected Telefone (){ }
        public Telefone(Telefone telefone)
        {
            this.Id = Guid.NewGuid();
            this.DDD = telefone.DDD;
            this.Numero = telefone.Numero;
            this.Descricao = telefone.Descricao;
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        public string Descricao { get; private set; }
        public virtual Pessoa Pessoa { get; set; }
        #endregion
        #region Methods
        public void ChangeDescription(string descricao)
        {
            this.Descricao = descricao;
        }
        public void ChangeDDD(string DDD)
        {
            this.DDD = DDD;
        }
        public void ChangeNumber(string numero)
        {
            this.Numero = numero;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.DDD, Errors.InvalidDDD);
            AssertionConcern.AssertArgumentLength(this.DDD, 2, 2, Errors.InvalidDDD);
            AssertionConcern.AssertArgumentNotNull(this.Numero, Errors.InvalidTelefone);
            AssertionConcern.AssertArgumentLength(this.Numero, 8, 8, Errors.InvalidTelefone);
        }

        #endregion

    }
}
