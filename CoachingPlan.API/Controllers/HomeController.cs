using CoachingPlan.API.Controllers;
using CoachingPlan.API.ViewModels;
using CoachingPlan.Domain.Contracts.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUserApplicationService _serviceUser;
        private readonly IRoleApplicationService _serviceRole;


        public HomeController(IUserApplicationService serviceUser, IRoleApplicationService serviceRole)
        {
            this._serviceUser = serviceUser;
            this._serviceRole = serviceRole;
        }

        [HttpGet]
        [Route("api/home/")]
        public Task<HttpResponseMessage> Get()
        {
            var user = _serviceUser.GetOneByEmailIncludePerson(User.Identity.Name);
            var roles = _serviceUser.GetAllRoles(user.Id);
            
            return CreateResponse(HttpStatusCode.OK, new UserRoleViewModel(user, roles));
        }
    }

}