using CoachingPlan.Domain.Enums;
using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class Person
    {
        #region Ctor
        protected Person(){}
        public Person(string name, string cpf, DateTime birthDate, EGenre genre, bool status, string phototgraph = null)
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
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF{ get; private set; }
        public System.DateTime BirthDate { get; private set; }
        public EGenre Genre { get; private set; }
        public bool Status { get; private set; }
        public string Photograph { get; private set; }

        public virtual ICollection<Phone> Phone { get; private set; }
        public virtual ICollection<Address> Address { get; private set; }
        public virtual ICollection<User> User { get; private set;}
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
        public void AddAddress(string cep, EStates state, string city, string street, int number, EAddressType type, Person person, string description = null)
        {
            Address address = new Address(cep, state, city, street, number, type, person, description);
            address.Validate();
            this.Address.Add(address);
        }
        public void RemoveAddress(Address address)
        {
            this.Address.Remove(address);
        }
        public void AddPhone(string ddd, string number, Person person, string description = null)
        {
            Phone phone = new Phone(ddd, number, person, description);
            phone.Validate();
            this.Phone.Add(phone);
        }
        public void RemovePhone(Phone phone)
        {
            this.Phone.Remove(phone);
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Name, Errors.InvalidName);
            AssertionConcern.AssertArgumentLength(this.Name, 4, 65, Errors.InvalidName);
            CPFAssertionConcern.AssertIsValid(this.CPF);
            AssertionConcern.AssertArgumentNotNull(this.CPF, Errors.InvalidCPF);
            AssertionConcern.AssertArgumentLength(this.CPF, 11, 11, Errors.InvalidCPF);
            AssertionConcern.AssertArgumentNotNull(this.BirthDate, Errors.InvalidBirthDate);
            AssertionConcern.AssertArgumentNotNull(this.Genre, Errors.InvalidGenre);
            AssertionConcern.AssertArgumentNotNull(this.Status, Errors.InvalidStatus);
            AssertionConcern.AssertArgumentNotEquals(this.Phone.Count, 0, Errors.PhoneNotFound);
            AssertionConcern.AssertArgumentNotEquals(this.Address.Count, 0, Errors.AddressNotFound);
        }
        #endregion
    }
}
