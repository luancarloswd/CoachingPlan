using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Usuario : IdentityUser
    {
        #region Ctor
        //protected Usuario() { }
        public Usuario()
        {
            //this.Sessao = new HashSet<Sessao>();
            //this.Avaliacao = new HashSet<Avaliacao>();
            //this.Mensagem = new HashSet<Mensagem>();
            this.Coachee = new HashSet<Coachee>();
            this.Coach = new HashSet<Coach>();
            this.Dispositivo = new HashSet<Dispositivo>();
        }
        #endregion
        #region Properties
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
        public virtual Pessoa Pessoa { get;  set; }
        //public virtual ICollection<Sessao> Sessao { get; set; }
        //public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        //public virtual ICollection<Mensagem> Mensagem { get; set; }
        public virtual ICollection<Coachee> Coachee { get; set; }
        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<Dispositivo> Dispositivo { get; set; }
        public string CurrentClientId { get; set; }
        #endregion
        #region Methods
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion
    }
}

