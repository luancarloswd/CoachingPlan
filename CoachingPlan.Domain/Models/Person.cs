using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Domain.Models
{
    public class Person
    {
        #region Ctor
        protected Person() { }
        public Person(string name, string cpf, DateTime birthDate, EGenre genre, bool status, ICollection<Address> address, ICollection<Phone> phone, string phototgraph = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.CPF = cpf;
            this.BirthDate = birthDate;
            this.Genre = genre;
            this.Status = status;
            this.Photograph = phototgraph;
            this.Phone = new List<Phone>();
            phone.ToList().ForEach(x => AddPhone(x));
            this.Address = new List<Address>();
            address.ToList().ForEach(x => AddAddress(x));
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public System.DateTime BirthDate { get; private set; }
        public EGenre Genre { get; private set; }
        public bool Status { get; private set; }
        public string Photograph { get; private set; }

        public virtual ICollection<Phone> Phone { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<User> User { get; set; }
        #endregion

        #region Methods

        public void ChangeName(string name)
        {
            if (!this.ChangeNameScopeIsValid(name))
                return;
            this.Name = name;
        }
        public void ChangeCPF(string cpf)
        {
            if (!this.ChangeCPFScopeIsValid(cpf))
                return;
            this.CPF = cpf;
        }
        public void ChangeBirthDate(DateTime birthDate)
        {
            if (!this.ChangeBirthDatedScopeIsValid(birthDate))
                return;
            this.BirthDate = birthDate;
        }
        public void ChangeStatus(bool status)
        {
            if (!this.ChangeStatusScopeIsValid(status))
                return;
            this.Status = status;
        }
        public void ChangePhotograph(string photograph)
        {
            this.Photograph = photograph;
        }
        public void AddAddress(Address address)
        {
            address.Validate();
            this.Address.Add(address);
        }
        public void RemoveAddress(Address address)
        {
            this.Address.Remove(address);
        }
        public void AddPhone(Phone phone)
        {
            phone.Validate();
            this.Phone.Add(phone);
        }
        public void RemovePhone(Phone phone)
        {
            this.Phone.Remove(phone);
        }
        public void Validate()
        {
            if (!this.CreatePersonScopeIsValid())
                return;
        }
        #endregion
    }
}
