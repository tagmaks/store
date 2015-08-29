using System.Data.Entity;
using GenericServices;
using Microsoft.AspNet.Identity.EntityFramework;
using Spa.Entities;
using Spa.Mappers;

namespace Spa.Infrastructure
{
    public class AppDbContext :
        IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>,
        IGenericServicesDbContext
    {
        public AppDbContext()
            : base("name=AppConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new SpaCreateDatabaseIfNotExists());
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferList> OfferLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductVideo> ProductVideos { get; set; }
        public DbSet<Ratio> Ratios { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapper());
            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new CustomerGroupMapper());
            modelBuilder.Configurations.Add(new OfferMapper());
            modelBuilder.Configurations.Add(new OfferListMapper());
            modelBuilder.Configurations.Add(new OrderMapper());
            modelBuilder.Configurations.Add(new OrderItemMapper());
            modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new ProductPhotoMapper());
            modelBuilder.Configurations.Add(new ProductVideoMapper());
            modelBuilder.Configurations.Add(new RatioMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}