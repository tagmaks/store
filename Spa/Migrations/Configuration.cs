using System.Data.Entity.Migrations;
using Spa.Infrastructure;

namespace Spa.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
#if DEBUG
        protected override void Seed(AppDbContext context)
        {
            new SpaDataSeeder(context).Seed();
        }
#endif 
    }
}
