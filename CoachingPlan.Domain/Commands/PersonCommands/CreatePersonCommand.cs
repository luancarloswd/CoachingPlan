using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.PersonCommands
{
    public class CreatePersonCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public EGenre Genre { get; set; }
        public bool Status { get; set; }
        public string Photograph { get; set; }

        public virtual ICollection<Phone> Phone { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<User> User { get; set; }

        public CreatePersonCommand(string name, string cpf, DateTime birthDate, EGenre genre, bool status, ICollection<Address> address, ICollection<Phone> phone, string phototgraph = null)
        {
            this.Name = name;
            this.CPF = cpf;
            this.BirthDate = birthDate;
            this.Genre = genre;
            this.Status = status;
            this.Photograph = phototgraph;
            this.Phone = phone;
            this.Address = address;
        }

    }
}
