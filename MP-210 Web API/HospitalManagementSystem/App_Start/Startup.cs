using System.Web.Http;
using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using HospitalManagementSystem.Models;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(HospitalManagementSystem.Startup))]

namespace HospitalManagementSystem
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //https://github.com/aamir-poswal/ASP.NET-WEB-API-OAuth-2.0-Token-Based-Authentication
            string PublicClientId = "self";
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/account/token"),
                AccessTokenExpireTimeSpan= TimeSpan.FromDays(1),
                //AuthorizeEndpointPath= new PathString("api/Account/ExternalLogin"),
                Provider = new MyAuthorizationServerProvider(PublicClientId)
            };
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);



            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "487818044896-atlocluihceg97uddbqjvbrhdos9e45l.apps.googleusercontent.com",
                ClientSecret= "k2wz9wLi1Uz5BIrlF_O-HBJw"
            });
            

            
        }
    }
}
