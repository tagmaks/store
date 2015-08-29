using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GenericServices.Core;
using Spa.Entities;
using Spa.Infrastructure;

namespace Spa.Dtos
{
    public class UserDtoAsync : EfGenericDtoAsync<User, UserDtoAsync>
    {
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
        [Required]
        public CustomerGroup CustomerGroup { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ratio> Ratios { get; set; }

        protected override CrudFunctions SupportedFunctions
        {
            get { return CrudFunctions.List; }
        }
    }
}