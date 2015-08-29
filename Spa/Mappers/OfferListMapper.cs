﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Spa.Entities;

namespace Spa.Mappers
{
    public class OfferListMapper: EntityTypeConfiguration<OfferList>
    {
        public OfferListMapper()
        {
            this.ToTable("OfferLists");

            this.HasKey(ol => ol.OfferListId);
            this.Property(ol => ol.OfferListId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(ol => ol.OfferListId).IsRequired();

            this.Property(ol => ol.StartDate).IsRequired();
            this.Property(ol => ol.StartDate).HasColumnType("smalldatetime");

            this.Property(ol => ol.EndDate).IsRequired();
            this.Property(ol => ol.EndDate).HasColumnType("smalldatetime");
        }
    }
}