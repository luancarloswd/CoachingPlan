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

namespace CoachingPlan.API.Security
{
    public class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {
        private readonly IUsuarioService _service;

        public  AuthorizationServerProvider(IUsuarioService service)
        {
            _service = service;
        }

        public async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var user = _service.Login(context.UserName, context.Password, false);

                if (user == null)
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

        public Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            throw new NotImplementedException();
        }

        public Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            throw new NotImplementedException();
        }

        public Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            throw new NotImplementedException();
        }

        public Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            throw new NotImplementedException();
        }

        public Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            throw new NotImplementedException();
        }
    }
}