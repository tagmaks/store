using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Spa.Entities;
using Spa.Enums;

namespace Spa.Infrastructure
{
    public class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        public Gender? Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
        public CustomerGroup CustomerGroup { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ratio> Ratios { get; set; }

        //Rest of code is removed for brevity
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}