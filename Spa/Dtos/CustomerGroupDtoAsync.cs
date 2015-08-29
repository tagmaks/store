using System.Collections.Generic;
using GenericServices.Core;
using Spa.Entities;
using Spa.Infrastructure;

namespace Spa.Dtos
{
    public class CustomerGroupDtoAsync : EfGenericDtoAsync<CustomerGroup, CustomerGroupDtoAsync>
    {
        public int CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public int Discount { get; set; }
        public OfferList OfferList { get; set; }
        public ICollection<User> Customers { get; set; }

        protected override CrudFunctions SupportedFunctions
        {
            get { return CrudFunctions.List; }
        }
    }
}