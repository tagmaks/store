using System;
using System.ComponentModel.DataAnnotations;
using GenericServices.Core;
using Spa.Infrastructure;

namespace Spa.Dtos
{
    public class UserDto: EfGenericDto<User, UserDto>
    {
        public int Id{ get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        public Enums.Gender? Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }

        protected override CrudFunctions SupportedFunctions => CrudFunctions.AllCrud;
    }
}