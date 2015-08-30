using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class ProductPhotoMapper: EntityTypeConfiguration<ProductPhoto>
    {
        public ProductPhotoMapper()
        {
            ToTable("ProductPhotos");

            HasKey(pp => pp.ProductPhotoId);
            Property(pp => pp.ProductPhotoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(pp => pp.ProductPhotoId).IsRequired();

            Property(pp => pp.PhotoName).IsRequired();
            Property(pp => pp.PhotoName).HasMaxLength(30);

            Property(pp => pp.Description).IsRequired();
            Property(pp => pp.Description).HasMaxLength(50);

            Property(pp => pp.Main).IsOptional();

            Property(pp => pp.OriginName).IsRequired();
            Property(pp => pp.OriginName).HasMaxLength(50);

            Property(pp => pp.ModifiedDate).IsOptional();
            Property(pp => pp.ModifiedDate).HasColumnType("smalldatetime");

            HasRequired(pp => pp.Product).WithMany(p => p.ProductPhotos).Map(p => p.MapKey("ProductId"));
        }
    }
}