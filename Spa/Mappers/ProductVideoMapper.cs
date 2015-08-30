using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class ProductVideoMapper: EntityTypeConfiguration<ProductVideo>
    {
        public ProductVideoMapper()
        {
            ToTable("ProductVideo");

            HasKey(pv => pv.ProductVideoId);
            Property(pv => pv.ProductVideoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(pv => pv.ProductVideoId).IsRequired();

            Property(pv => pv.Name).IsRequired();
            Property(pv => pv.Name).HasMaxLength(30);

            Property(pv => pv.Description).IsRequired();
            Property(pv => pv.Description).HasMaxLength(50);

            HasRequired(pv => pv.Product).WithMany(p => p.ProductVideos).Map(p => p.MapKey("ProductId"));
        }
    }
}