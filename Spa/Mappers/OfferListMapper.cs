using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class OfferListMapper: EntityTypeConfiguration<OfferList>
    {
        public OfferListMapper()
        {
            ToTable("OfferLists");

            HasKey(ol => ol.OfferListId);
            Property(ol => ol.OfferListId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(ol => ol.OfferListId).IsRequired();

            Property(ol => ol.StartDate).IsRequired();
            Property(ol => ol.StartDate).HasColumnType("smalldatetime");

            Property(ol => ol.EndDate).IsRequired();
            Property(ol => ol.EndDate).HasColumnType("smalldatetime");
        }
    }
}