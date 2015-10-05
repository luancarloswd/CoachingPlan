using CoachingPlan.Infraestructure.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CoachingPlan.Infraestructure.Identity
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AppDataContext>();
            var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(appDbContext));

            return appRoleManager;
        }
    }
}
