using Owin;
using Spa.Infrastructure;

namespace Spa
{
	public partial class Startup
	{
        private void ConfigurationOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
        }
    }
}