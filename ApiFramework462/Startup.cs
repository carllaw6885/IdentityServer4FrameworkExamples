using System.Collections.Generic;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ApiFramework462.Startup))]

namespace ApiFramework462
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:5001",
                ClientId = "api2",
                ClientSecret = "secret",
                RequiredScopes = new List<string> { "api2" },
                ValidationMode = ValidationMode.ValidationEndpoint
            });

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);

        }
    }
}
