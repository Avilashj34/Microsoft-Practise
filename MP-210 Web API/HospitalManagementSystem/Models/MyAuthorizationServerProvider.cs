using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;

namespace HospitalManagementSystem.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public MyAuthorizationServerProvider(string publicClientId)
        {
            _publicClientId = publicClientId ?? throw new ArgumentNullException("publicClientId");
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            using(TokenAuthentication _repo = new TokenAuthentication())
            {
                var account = _repo.ValidateUser(context.UserName,context.Password);
                if (account == null)
                {
                    context.SetError("Invalid Grant","Provided username and password doesn't match");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Email",account.Email));
                context.Validated(identity);
            }
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/Login.html");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }
            return Task.FromResult<object>(null);
        }





    }
}