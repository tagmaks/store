using System.Web.Http;

namespace Spa
{
    public partial class Startup
    {
        private void ConfigureWebApi(HttpConfiguration httpConfig)
        {
            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}