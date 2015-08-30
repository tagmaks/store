using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class RatioMapper: EntityTypeConfiguration<Ratio>
    {
        public RatioMapper()
        {
            ToTable("Ratios");

            HasKey(r => r.RatioId);
            Property(r => r.RatioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.RatioId).IsRequired();

            Property(r => r.ProductRatio).IsRequired();

            Property(r => r.AddDate).IsOptional();
            Property(r => r.AddDate).HasColumnType("smalldatetime");

            HasRequired(r => r.Product).WithMany(p => p.Ratios).Map(p => p.MapKey("ProductId"));
            HasRequired(r => r.Customer).WithMany(c => c.Ratios).Map(p => p.MapKey("CustomerId"));
        }
    }
}