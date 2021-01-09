using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataLibrary.Validations;

namespace OurHospital.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name*")]
        [RegularExpression(@"^[a-zA-Z_]*$", ErrorMessage = "Accept only letters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name*")]
        [RegularExpression(@"^[a-zA-Z_]*$", ErrorMessage = "Accept only letters")]
        public string LastName { get; set; }

        [Required]
        [ValidationPesel]
        [Display(Name = "PESEL Number*")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Accept only numbers.")]
        public string PeselNumber { get; set; }

        [Display(Name = "PWZ Number (doctors)")]
        public string PWZNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username*")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password*")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
