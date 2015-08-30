using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class OrderMapper: EntityTypeConfiguration<Order>
    {
        public OrderMapper()
        {
            ToTable("Orders");

            HasKey(o => o.OrderId);
            Property(o => o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.OrderId).IsRequired();

            Property(o => o.OrderDiscount).IsOptional();

            Property(o => o.OrderDate).IsOptional();
            Property(o => o.OrderDate).HasColumnType("smalldatetime");

            Property(o => o.PaymentDate).IsOptional();
            Property(o => o.PaymentDate).HasColumnType("smalldatetime");

            Property(o => o.CustomerComment).IsOptional();
            Property(o => o.CustomerComment).HasMaxLength(255);

            Property(o => o.AdminOrderComment).IsOptional();
            Property(o => o.AdminOrderComment).HasMaxLength(255);

            Property(o => o.ShippingCost).IsRequired();

            HasRequired(o => o.Customer).WithMany(c => c.Orders).Map(c => c.MapKey("CustomerId"));
        }
    }
}