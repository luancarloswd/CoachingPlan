using CoachingPlan.Domain.Contracts.Services;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace CoachingPlan.API.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        IUserApplicationService _userService;
        IRoleApplicationService _roleService;

        public SimpleAuthorizationServerProvider(IUserApplicationService userService, IRoleApplicationService roleService)
        {
            this._userService = userService;
            this._roleService = roleService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var user = _userService.Authenticate(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            foreach (var item in _userService.GetAllRoles(user.Id))
                identity.AddClaim(new Claim(ClaimTypes.Role, item));
            GenericPrincipal principal = new GenericPrincipal(identity, new string[] {});
            Thread.CurrentPrincipal = principal;


            context.Validated(identity);
        }
    }

}