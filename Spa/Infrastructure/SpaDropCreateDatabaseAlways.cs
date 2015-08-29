using Spa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Spa.Data.Infrastructure
{
    public class SpaDropCreateDatabaseAlways : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            new SpaDataSeeder(context).Seed();
            base.Seed(context);
        }
    }
}