using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CoachingPlan.Infraestructure.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AppDataContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<User>(appDbContext));

            return appUserManager;
        }
    }
}
