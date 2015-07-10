using System.Web.Http;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace CoachingPlan.API.App_start
{

    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer(); // Your mappings here 
            config.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}