using System;

namespace CoachingPlan.Domain.Commands.PhoneCommands
{
    public class CreatePhoneCommand
    {
        public string DDD { get; private set; }
        public string Number { get; private set; }
        public string Description { get; private set; }
        public Guid IdPerson { get; set; }

        public CreatePhoneCommand(string ddd, string number, Guid idPerson, string description = null)
        {
            this.DDD = ddd;
            this.Number = number;
            this.IdPerson = IdPerson;
            this.Description = description;           
        }
    }
}
