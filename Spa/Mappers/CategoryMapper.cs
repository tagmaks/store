using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class CategoryMapper: EntityTypeConfiguration<Category>
    {
        public CategoryMapper()
        {
            ToTable("Categories");

            HasKey(c => c.CategoryId);
            Property(c => c.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.CategoryId).IsRequired();

            Property(c => c.Name).IsRequired();
            Property(c => c.Name).HasMaxLength(30);

            Property(c => c.Description).IsOptional();
            Property(c => c.Description).HasMaxLength(100);

            Property(c => c.Picture).IsOptional();
            Property(c => c.Picture).HasMaxLength(100);

            Property(c => c.MiniPicture).IsOptional();
            Property(c => c.MiniPicture).HasMaxLength(100);

            Property(c => c.Enabled).IsOptional();
        }
    }
}