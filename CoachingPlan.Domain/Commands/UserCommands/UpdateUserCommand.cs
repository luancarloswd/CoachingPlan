using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.UserCommands
{
    public class UpdateUserCommand
    {
        public string Id { get; set; }
        public ETypeUser Type { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
        public Guid IdPerson { get; private set; }
        public UpdateUserCommand(string id, string email, string userName, string password, Guid idPerson)
        {
            this.Id = id;
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
            this.IdPerson = idPerson;
        }
    }
}
