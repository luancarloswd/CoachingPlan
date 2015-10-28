using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.MessageCommands
{
    public class CreateMessageCommand
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public string BodyMessage { get; private set; }
        public string Destination { get; private set; }
        public DateTime Date { get; private set; }
        public bool Status { get; private set; }

        public virtual User User { get; private set; }

        public CreateMessageCommand(string bodyMessage, string destination, DateTime date, string idUser)
        {
            this.BodyMessage = bodyMessage;
            this.Destination = destination;
            this.Date = date;
            this.IdUser = idUser;
        }
    }
}
