using System.Data.Entity.ModelConfiguration;
using Spa.Infrastructure;

namespace Spa.Mappers
{
    public class UserMapper: EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            Property(ap => ap.Id).HasColumnName("UserID");

            Property(c => c.DateOfBirth).IsOptional();
            Property(c => c.DateOfBirth).HasColumnType("smalldatetime");

            Property(c => c.SubscribedNews).IsOptional();

            HasOptional(c => c.CustomerGroup).WithMany(cg => cg.Customers).Map(cg => cg.MapKey("CustomerGroupId"));
        }
    }
}