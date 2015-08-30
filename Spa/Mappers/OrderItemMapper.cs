using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class OrderItemMapper: EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMapper()
        {
            ToTable("OrderItems");

            HasKey(oi => oi.OrderItemId);
            Property(oi => oi.OrderItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(oi => oi.OrderItemId).IsRequired();

            Property(oi => oi.Amount).IsRequired();

            HasRequired(oi => oi.Order).WithMany(o => o.OrderItems).Map(o => o.MapKey("OrderId"));
            HasRequired(oi => oi.Product).WithMany(p => p.OrderItems).Map(o => o.MapKey("ProductId"));
        }
    }
}