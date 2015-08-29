using System.Data.Entity;

namespace Spa.Infrastructure
{
    class SpaCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            new SpaDataSeeder(context).Seed();
            base.Seed(context);
        }
    }
}
