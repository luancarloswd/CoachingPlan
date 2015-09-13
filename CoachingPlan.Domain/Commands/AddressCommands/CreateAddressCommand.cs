using CoachingPlan.Domain.Enums;
using System;

namespace CoachingPlan.Domain.Commands.AddressCommands
{
    public class CreateAddressCommand
    {
        public string CEP { get; set; }
        public EStates State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public EAddressType Type { get; set; }
        public string Description { get; set; }
        public Guid IdPerson { get; set; }
        public CreateAddressCommand(string cep, EStates state, string city, string street, int number, EAddressType type, Guid idPerson, string description = null)
        {
            this.IdPerson = idPerson;
            this.CEP = cep;
            this.State = state;
            this.City = city;
            this.Street = street;
            this.Number = number;
            this.Type = type;
            this.Description = description;
        }

    }
}
