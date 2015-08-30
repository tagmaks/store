using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class OfferMapper: EntityTypeConfiguration<Offer>
    {
        public OfferMapper()
        {
            ToTable("Offers");

            HasKey(o => o.OfferId);
            Property(o => o.OfferId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.OfferId).IsRequired();

            Property(o => o.Amount).IsRequired();

            Property(o => o.Price).IsRequired();

            Property(o => o.ShipPrice).IsRequired();

            HasRequired(o => o.Product).WithMany(p => p.Offers).Map(p => p.MapKey("ProductId"));
            HasRequired(o => o.OfferList).WithMany(ol => ol.Offers).Map(ol => ol.MapKey("OfferListId"));
        }
    }
}