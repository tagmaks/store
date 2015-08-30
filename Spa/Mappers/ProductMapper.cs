using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class ProductMapper : EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            ToTable("Products", "catalog");

            HasKey(p => p.ProductId);
            Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.ProductId).IsRequired();

            Property(p => p.Name).IsRequired();
            Property(p => p.Name).HasMaxLength(30);

            Property(p => p.Price).IsRequired();

            Property(p => p.Ratio).IsOptional();

            Property(p => p.Discount).IsOptional();

            Property(p => p.Weight).IsOptional();

            Property(p => p.Size).IsOptional();

            Property(p => p.IsFreeShipping).IsOptional();

            Property(p => p.ItemSold).IsOptional();

            Property(p => p.Enabled).IsOptional();

            Property(p => p.ShortDescription).IsRequired();

            Property(p => p.Description).IsRequired();

            Property(p => p.DateAdded).IsOptional();
            Property(p => p.DateAdded).HasColumnType("smalldatetime");

            Property(p => p.DateModified).IsOptional();
            Property(p => p.DateModified).HasColumnType("smalldatetime");

            Property(p => p.Recomended).IsOptional();

            Property(p => p.New).IsOptional();

            Property(p => p.OnSale).IsOptional();

            HasMany(p => p.Categories).WithMany(c => c.Products).Map(m =>
                {
                    m.ToTable("ProductCategories");
                    m.MapLeftKey("ProductId");
                    m.MapRightKey("CategoryId");
                });
        }
    }
}