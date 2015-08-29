using System.Collections.Generic;
using Spa.Infrastructure;

namespace Spa.Entities
{
    public class CustomerGroup
    {
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public int Discount { get; set; }
        public OfferList OfferList { get; set; }
        public ICollection<User> Customers { get; set; }
    }
}
