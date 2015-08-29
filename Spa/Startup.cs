using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;

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

            ConfigureDi(httpConfig);

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }
    }
}
