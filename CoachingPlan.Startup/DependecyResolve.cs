using System.Data.Entity;
using System.Web;
using Microsoft.Practices.Unity;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Infraestructure.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Business.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;


namespace CoachingPlan.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            //context
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());

            //repositories
            container.RegisterType<ITelefoneRepository, TelefoneRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoRepository, EnderecoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaRepository, PessoaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachRepository, CoachRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoacheeRepository, CoacheeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFragilidadeRepository, FragilidadeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPontoForteRepository, PontoForteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEspecialidadeRepository, EspecialidadeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFormacaoRepository, FormacaoRepository>(new HierarchicalLifetimeManager());

            //Services
            container.RegisterType<ITelefoneService, TelefoneService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEnderecoService, EnderecoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaService, PessoaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoachService, CoachService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICoacheeService, CoacheeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFragilidadeService, FragilidadeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPontoForteService, PontoForteService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEspecialidadeService, EspecialidadeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFormacaoService, FormacaoService>(new HierarchicalLifetimeManager());

            //Identity
            container.RegisterType(typeof(UserManager<>),
            new InjectionConstructor(typeof(IUserStore<>)));
            container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
           // container.RegisterType<IdentityUser, Usuario>(new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, AppDataContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => new OwinContext().Authentication));
            
            //Models
            container.RegisterType<Usuario, Usuario>(new HierarchicalLifetimeManager());
            container.RegisterType<Pessoa, Pessoa>(new HierarchicalLifetimeManager());
            container.RegisterType<Telefone, Telefone>(new HierarchicalLifetimeManager());
            container.RegisterType<Endereco, Endereco>(new HierarchicalLifetimeManager());
        }
    }
}