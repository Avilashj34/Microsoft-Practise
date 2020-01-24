using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using TokenAuthenticationAssinment1.Models;

[assembly: OwinStartup(typeof(TokenAuthenticationAssinment1.Startup))]

namespace TokenAuthenticationAssinment1
{
    public class Startup
    {
        public static string publicClientId { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"), // Path for token generating
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(25), // Validity of token
                Provider = new AuthorizationServerProvider(publicClientId) // class will validaate  user credential
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            /*app.UseGoogleAuthentication(new GoogleOauthAuthenticationOptions()
            {
                clientId
            });*/
        }
    }
}
