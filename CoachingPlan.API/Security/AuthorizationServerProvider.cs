using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Resources.Messages;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CoachingPlan.Domain.Models;

namespace CoachingPlan.API.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioService _service;

        public  AuthorizationServerProvider(IUsuarioService service)
        {
            _service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
               ICollection<Usuario> users =  _service.GetAll();
                var user = _service.Login(context.UserName, context.Password, false);

                if (user.Result == null)
                {
                    context.SetError("invalid_grant", Errors.InvalidCredentials);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Result.Email));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Result.UserName));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", Errors.InvalidCredentials);
            }
        }

    }
}