using System;
using System.ComponentModel.DataAnnotations;

namespace Spa.Dtos
{
    public class NewUserDto
    {
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Enums.Gender? Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool SubscribedNews { get; set; }
    }
}