using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;


namespace TokenAuthenticationAssinment1.Models
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public AuthorizationServerProvider(string publicClientId)
        {
            _publicClientId = publicClientId ?? throw new ArgumentNullException("publicClientId");
        }


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            using (UserMasterRepository repo = new UserMasterRepository())
            {
                var user =repo.Validate(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provide UserName and Password");
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim("Role", user.UserRoles));
                identity.AddClaim(new Claim("Email", user.UserEmailId));
                context.Validated(identity);
            }
        }


        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri exceptedRootUri = new Uri(context.Request.Uri,"/Login.html");
                if (exceptedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }
            return Task.FromResult<object>(null);
            
        }
    }
}