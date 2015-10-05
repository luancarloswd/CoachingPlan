using CoachingPlan.Domain.Enums;
using System;

namespace CoachingPlan.Domain.Commands.AddressCommands
{
    public class ChangeAddressCommand
    {
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public EStates State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public EAddressType Type { get; set; }
        public string Description { get; set; }
        public ChangeAddressCommand(Guid Id, string cep, EStates state, string city, string street, int number, EAddressType type, string description = null)
        {
            this.Id = Id;
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
