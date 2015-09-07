using System.Data.Entity;
using Microsoft.Practices.Unity;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Contracts.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using CoachingPlan.SharedKernel.Events;
using CoachingPlan.CrossCutting;

namespace CoachingPlan.SharedKernel
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //context
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());

            //unity of work
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            //Handler
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

            //repositories


            //Services


            //Identity
            container.RegisterType(typeof(UserManager<>),
            new InjectionConstructor(typeof(IUserStore<>)));
            container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType<DbContext, AppDataContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => new OwinContext().Authentication));
            
            //Models
            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
            container.RegisterType<Person, Person>(new HierarchicalLifetimeManager());
            container.RegisterType<Phone, Phone>(new HierarchicalLifetimeManager());
            container.RegisterType<Address, Address>(new HierarchicalLifetimeManager());
        }
    }
}