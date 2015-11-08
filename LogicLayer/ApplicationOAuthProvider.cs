using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DbLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace LogicLayer
{
    public class AbitInfoOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthService _authService;

        public AbitInfoOAuthProvider(IAuthService authService)
        {
            _authService = authService;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            AbitInfoIdentityUser user = await _authService.FindUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }

            ClaimsIdentity oAuth = await _authService.CreateIdentity(user, DefaultAuthenticationTypes.ExternalBearer);
            List<Claim> roles = oAuth.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            AuthenticationProperties properties = CreateProperties(user.UserName, roles);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuth, properties);
            context.Validated(ticket);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var token = context.OwinContext.Request.Cookies["authrorizationData"];
            context.Validated();
        }

        public static AuthenticationProperties CreateProperties(string userName, List<Claim> roles)
        {
            string rolesString = Newtonsoft.Json.JsonConvert.SerializeObject(roles.Select(x => x.Value));
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                {"userName", userName},
                {"roles", rolesString}
            };
            return new AuthenticationProperties(data);
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
        }
    }
}