using System;

namespace CoachingPlan.Domain.Commands.PhoneCommands
{
     public class ChangePhoneCommand
    {
        public Guid Id { get; set; }
        public string DDD { get;  set; }
        public string Number { get;  set; }
        public string Description { get;  set; }

        public ChangePhoneCommand(string ddd, string number, string description = null)
        {
            this.DDD = ddd;
            this.Number = number;
            this.Description = description;           
        }
    }
}
