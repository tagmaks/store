using System.Data.Entity.ModelConfiguration;
using Spa.Infrastructure;

namespace Spa.Mappers
{
    public class UserMapper: EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            this.Property(ap => ap.Id).HasColumnName("UserID");

            this.Property(c => c.DateOfBirth).IsOptional();
            this.Property(c => c.DateOfBirth).HasColumnType("smalldatetime");

            this.Property(c => c.SubscribedNews).IsOptional();

            this.HasOptional(c => c.CustomerGroup).WithMany(cg => cg.Customers).Map(cg => cg.MapKey("CustomerGroupId"));
        }
    }
}