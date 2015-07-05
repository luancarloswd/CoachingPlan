using CoachingPlan.Domain.Enums;
using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Endereco
    {
        #region ctor
        protected Endereco(){ }
        public Endereco(Endereco endereco)
        {
            this.Id = Guid.NewGuid();
            this.CEP = endereco.CEP;
            this.Estado = endereco.Estado;
            this.Cidade = endereco.Cidade;
            this.Rua = endereco.Rua;
            this.Numero = endereco.Numero;
            this.Tipo = endereco.Tipo;
            this.Descricao = endereco.Descricao;
        }
        #endregion
        #region properties
        public Guid Id { get; private set; }
        public string CEP { get; private set; }
        public EEstado.Estados Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public ETipoEndereco.TipoEndereco Tipo { get; private set; }
        public string Descricao { get; private set; }
        public virtual Pessoa Pessoa { get; set; }

         #endregion
        #region Methods
        public void ChangeCEP(string CEP)
        {
            this.CEP = CEP;
        }
        public void ChangeEstado(CoachingPlan.Domain.Enums.EEstado.Estados estado)
        {
            this.Estado = estado;
        }
        public void ChangeCidade(string cidade)
        {
            this.Cidade = cidade;
        }
        public void ChangeRua(string rua)
        {
            this.Rua = rua;
        }
        public void ChangeNumero(int numero)
        {
            this.Numero = numero;
        }
        public void ChangeTipo(ETipoEndereco.TipoEndereco tipo)
        {
            this.Tipo = tipo;
        }
        public void ChangeTipo(string descricao)
        {
            this.Descricao = descricao;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.CEP, Errors.InvalidCEP);
            AssertionConcern.AssertArgumentLength(this.CEP, 8, 8, Errors.InvalidCEP);
            CEPAssertionConcern.AssertIsValid(this.CEP);
            AssertionConcern.AssertArgumentNotNull(this.Estado, Errors.InvalidEstado);
            AssertionConcern.AssertArgumentNotNull(this.Cidade, Errors.InvalidCidade);
            AssertionConcern.AssertArgumentLength(this.Cidade, 3, 35, Errors.InvalidCidade);
            AssertionConcern.AssertArgumentNotNull(this.Rua, Errors.InvalidRua);
            AssertionConcern.AssertArgumentLength(this.Rua, 3, 70, Errors.InvalidRua);
            AssertionConcern.AssertArgumentNotNull(this.Numero, Errors.InvalidNumero);
            AssertionConcern.AssertArgumentRange(this.Numero, 2, 2, Errors.InvalidNumero);
            AssertionConcern.AssertArgumentNotNull(this.Tipo, Errors.InvalidTipoEndereco);
            AssertionConcern.AssertArgumentLength(this.Descricao, 3, 40, Errors.InvalidDescricao);
        }
        #endregion
    }
}
