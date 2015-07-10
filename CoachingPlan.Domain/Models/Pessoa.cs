using CoachingPlan.Domain.Enums;
using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Pessoa
    {
        #region Ctor
        protected Pessoa(){}
        public Pessoa(string nome, string cpf, DateTime dataNacimneto, EGenero.Genero genero, bool status, string foto = null)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.CPF = cpf;
            this.DataNascimento = dataNacimneto;
            this.Genero = genero;
            this.Status = status;
            this.Foto = foto;
            this.Telefone = new HashSet<Telefone>();
            this.Endereco = new HashSet<Endereco>();
            this.Usuario = new HashSet<Usuario>();
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF{ get; private set; }
        public System.DateTime DataNascimento { get; private set; }
        public EGenero.Genero Genero { get; private set; }
        public bool Status { get; private set; }
        public string Foto { get; private set; }

        public virtual ICollection<Telefone> Telefone { get; private set; }
        public virtual ICollection<Endereco> Endereco { get; private set; }
        public virtual ICollection<Usuario> Usuario { get; private set; }
        #endregion

        #region Methods
        public void ChangeNome(string nome)
        {
            this.Nome = nome;
        }
        public void ChangeCPF(string CPF)
        {
            this.CPF = CPF;
        }
        public void ChangeDataNascimento(DateTime data)
        {
            this.DataNascimento = data;
        }
        public void ChangeStatus(bool satus)
        {
            this.Status = satus;
        }
        public void ChangeFoto(string foto)
        {
            this.Foto = foto;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.InvalidNome);
            AssertionConcern.AssertArgumentLength(this.Nome, 5, 65, Errors.InvalidNome);
            CPFAssertionConcern.AssertIsValid(this.CPF);
            AssertionConcern.AssertArgumentNotNull(this.CPF, Errors.InvalidCPF);
            AssertionConcern.AssertArgumentLength(this.CPF, 11, 11, Errors.InvalidCPF);
            AssertionConcern.AssertArgumentNotNull(this.DataNascimento, Errors.InvalidDataNascimento);
            AssertionConcern.AssertArgumentNotNull(this.Genero, Errors.InvalidGenero);
            AssertionConcern.AssertArgumentNotNull(this.Status, Errors.InvalidStatus);
        }
        #endregion
    }
}
