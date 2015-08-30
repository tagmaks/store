using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class CustomerGroupMapper: EntityTypeConfiguration<CustomerGroup>
    {
        public CustomerGroupMapper()
        {
            ToTable("CustomerGroups");

            HasKey(cg => cg.CustomerGroupId);
            Property(cg => cg.CustomerGroupId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(cg => cg.CustomerGroupId).IsRequired();

            Property(cg => cg.GroupName).IsRequired();
            Property(cg => cg.GroupName).HasMaxLength(30);

            Property(cg => cg.Discount).IsOptional();

            HasOptional(cg => cg.OfferList).WithMany(of => of.CustomerGroups).Map(of => of.MapKey("OfferListId"));
        }
    }
}