using Owin;
using System.Web.Http;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Spa.Startup))]

namespace Spa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigurationOAuthTokenGeneration(app);

            ConfigureWebApi(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }
    }
}
