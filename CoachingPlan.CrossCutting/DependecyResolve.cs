using System.Data.Entity;
using Microsoft.Practices.Unity;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using CoachingPlan.SharedKernel.Events;
using CoachingPlan.SharedKernel;
using CoachingPlan.Infraestructure.Identity;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.ApplicationService;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Infraestructure.Repositories;
using CoachingPlan.Infraestructure.Identity.Services;

namespace CoachingPlan.CrossCutting
{
    public static class DependencyResolver
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// ContainerControlledLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Resolve(UnityContainer container)
        {

            //context
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());

            //Handler
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

            //unity of work
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            //repositories
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleRepository, RoleRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressRepository, AddressRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneRepository, PhoneRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachRepository, CoachRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoacheeRepository, CoacheeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFormationRepository, FormationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IWeaknessRepository, WeaknessRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStrongPointRepository, StrongPointRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISpecialityRepository, SpecialityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachRepository, CoachRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoacheeRepository, CoacheeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISessionRepository, SessionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceRepository, ServiceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPerformanceIndicatorRepository, PerformanceIndicatorRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachingProcessRepository, CoachingProcessRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBudgetRepository, BudgetRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionPlanRepository, ActionPlanRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IObjectiveRepository, ObjectiveRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMarkRepository, MarkRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobRepository, JobRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEvaluationCoachRepository, EvaluationCoachRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEvaluationCoacheeRepository, EvaluationCoacheeRepository>(new HierarchicalLifetimeManager());


            //Identity
            container.RegisterType(typeof(UserManager<>), new InjectionConstructor(typeof(IUserStore<>)));
             container.RegisterType<UserManager<User>, ApplicationUserManager>(new HierarchicalLifetimeManager());
            container.RegisterType<RoleManager<IdentityRole>, ApplicationRoleManager>(new HierarchicalLifetimeManager());;
            container.RegisterType<IUser>(new InjectionFactory(c => c.Resolve<IUser>()));
            container.RegisterType<IRole>(new InjectionFactory(c => c.Resolve<IRole>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType(typeof(IRoleStore<IdentityRole, string>), typeof(RoleStore<IdentityRole>));
            container.RegisterType<DbContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => new OwinContext().Authentication));
            container.RegisterType<IIdentityMessageService, EmailService>();


            //Services
            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleApplicationService, RoleApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonApplicationService, PersonApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressApplicationService, AddressApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhoneApplicationService, PhoneApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachApplicationService, CoachApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoacheeApplicationService, CoacheeApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFormationApplicationService, FormationApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IWeaknessApplicationService, WeaknessApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStrongPointApplicationService, StrongPointApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISpecialityApplicationService, SpecialityApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachApplicationService, CoachApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoacheeApplicationService, CoacheeApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISessionApplicationService, SessionApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceApplicationService, ServiceApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPerformanceIndicatorApplicationService, PerformanceIndicatorApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachingProcessApplicationService, CoachingProcessApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBudgetApplicationService, BudgetApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionPlanApplicationService, ActionPlanApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IObjectiveApplicationService, ObjectiveApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMarkApplicationService, MarkApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IJobApplicationService, JobApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEvaluationCoachApplicationService, EvaluationCoachApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEvaluationCoacheeApplicationService, EvaluationCoacheeApplicationService>(new HierarchicalLifetimeManager());
        }
    }
}