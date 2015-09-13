﻿using System.Data.Entity;
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

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
            //context
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());

            //Handler
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

            //unity of work
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());


            //repositories
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
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


            //Identity
            container.RegisterType(typeof(UserManager<>), new InjectionConstructor(typeof(IUserStore<>)));
            container.RegisterType<UserManager<User>, ApplicationUserManager>(new HierarchicalLifetimeManager());
            container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType<DbContext, AppDataContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => new OwinContext().Authentication));

            //Services
            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
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

        }
    }
}