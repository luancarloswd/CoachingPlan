using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Infraestructure.Identity.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;

namespace CoachingPlan.Infraestructure.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {

            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            this.UserTokenProvider = new DataProtectorTokenProvider<User, string>
                (new DpapiDataProtectionProvider("CoachingPlan")
                .Create("UserToken")) as IUserTokenProvider<User, string>;
            this.EmailService = new EmailService();

            this.UserTokenProvider = new DataProtectorTokenProvider<User, string>
            (new DpapiDataProtectionProvider("CoachingPlan").Create("UserToken"))
            {
                //Code for email confirmation and reset password life time
                TokenLifespan = TimeSpan.FromHours(6)
            } as IUserTokenProvider<User, string>;
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AppDataContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<User>(appDbContext));

            // Configure validation logic for usernames
            appUserManager.UserValidator = new UserValidator<User>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            appUserManager.UserTokenProvider = new DataProtectorTokenProvider<User, string>
                (new DpapiDataProtectionProvider("CoachingPlan")
                .Create("UserToken")) as IUserTokenProvider<User, string>;
            appUserManager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<User, string>
                (new DpapiDataProtectionProvider("CoachingPlan").Create("UserToken"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6)
                } as IUserTokenProvider<User, string>;

                appUserManager.EmailService = new EmailService();
            }

            return appUserManager;
        }
    }
}
