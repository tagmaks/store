using System;
using System.Collections.Generic;

namespace Spa.Entities
{
    public class OfferList
    {
        public int OfferListId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerGroup> CustomerGroups { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}