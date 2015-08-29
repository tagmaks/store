using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class CustomerGroupMapper: EntityTypeConfiguration<CustomerGroup>
    {
        public CustomerGroupMapper()
        {
            this.ToTable("CustomerGroups");

            this.HasKey(cg => cg.CustomerGroupId);
            this.Property(cg => cg.CustomerGroupId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(cg => cg.CustomerGroupId).IsRequired();

            this.Property(cg => cg.GroupName).IsRequired();
            this.Property(cg => cg.GroupName).HasMaxLength(30);

            this.Property(cg => cg.Discount).IsOptional();

            this.HasOptional(cg => cg.OfferList).WithMany(of => of.CustomerGroups).Map(of => of.MapKey("OfferListId"));
        }
    }
}