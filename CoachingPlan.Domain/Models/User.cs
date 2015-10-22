using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Models
{
    public class User : IdentityUser
    {
        #region Ctor
        public User(){}
        public User(Guid idPerson, string email, string userName) 
        {
            this.IdPerson = idPerson;
            this.Email = email;
            this.UserName = userName;
            this.Session = new HashSet<Session>();
            this.Message = new HashSet<Message>();
            this.Coachee = new HashSet<Coachee>();
            this.Coach = new HashSet<Coach>();
        }
        #endregion

        #region Properties

        public override string Id{ get; set; }
        public override string Email { get; set; }
        public override string UserName { get; set; }
        public override bool EmailConfirmed { get; set; }
        public override string PasswordHash { get; set; }
        public override string SecurityStamp { get; set; }
        public override string PhoneNumber { get; set; }
        public override bool PhoneNumberConfirmed { get; set; }
        public override bool TwoFactorEnabled { get; set; }
        public override DateTime? LockoutEndDateUtc { get; set; }
        public override bool LockoutEnabled { get; set; }
        public override int AccessFailedCount { get; set; }
        public Guid IdPerson { get;  set; }
        public virtual Person Person { get;  set; }
        public virtual ICollection<Session> Session { get; private set; }
        public virtual ICollection<Message> Message { get; private set; }
        public virtual ICollection<Coachee> Coachee { get; private set; }
        public virtual ICollection<Coach> Coach { get; private set; }

        #endregion

        #region Methods
        public void AddMessage(Message message)
        {
            this.Message.Add(message);
        }
        public void Validate()
        {

        }
        #endregion
    }
}

