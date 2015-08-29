using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Resources.Messages;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
               _service.Register(context.UserName, context.UserName, context.Password);
                ICollection<User> users = _service.GetAll();
                
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", Errors.InvalidCredentials);
            }
        }

    }
}