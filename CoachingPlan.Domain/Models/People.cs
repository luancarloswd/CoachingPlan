using CoachingPlan.Domain.Enums;
using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class People
    {
        #region Ctor
        protected People(){}
        public People(string name, string cpf, DateTime birthDate, EGenre.Genre genre, bool status, string phototgraph = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.CPF = cpf;
            this.BirthDate = birthDate;
            this.Genre = genre;
            this.Status = status;
            this.Photograph = phototgraph;
            this.Phone = new HashSet<Phone>();
            this.Address = new HashSet<Address>();
            this.User = new HashSet<User>();
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF{ get; private set; }
        public System.DateTime BirthDate { get; private set; }
        public EGenre.Genre Genre { get; private set; }
        public bool Status { get; private set; }
        public string Photograph { get; private set; }

        public virtual ICollection<Phone> Phone { get; private set; }
        public virtual ICollection<Address> Address { get; private set; }
        public virtual ICollection<User> User { get; private set; }
        #endregion

        #region Methods
        public void ChangeName(string name)
        {
            this.Name = name;
        }
        public void ChangeCPF(string CPF)
        {
            this.CPF = CPF;
        }
        public void ChangeBirthDate(DateTime birthDate)
        {
            this.BirthDate = birthDate;
        }
        public void ChangeStatus(bool satus)
        {
            this.Status = satus;
        }
        public void ChangePhotograph(string photograph)
        {
            this.Photograph = photograph;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Name, Errors.InvalidNome);
            AssertionConcern.AssertArgumentLength(this.Name, 5, 65, Errors.InvalidNome);
            CPFAssertionConcern.AssertIsValid(this.CPF);
            AssertionConcern.AssertArgumentNotNull(this.CPF, Errors.InvalidCPF);
            AssertionConcern.AssertArgumentLength(this.CPF, 11, 11, Errors.InvalidCPF);
            AssertionConcern.AssertArgumentNotNull(this.BirthDate, Errors.InvalidDataNascimento);
            AssertionConcern.AssertArgumentNotNull(this.Genre, Errors.InvalidGenero);
            AssertionConcern.AssertArgumentNotNull(this.Status, Errors.InvalidStatus);
        }
        #endregion
    }
}
