using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Validations;

namespace OurHospital.Models
{
    public class UserEdit
    {
        public UserEdit() { }

        public UserEdit(ApplicationUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            PeselNumber = user.PeselNumber;
            PWZNumber = user.PWZNumber;
            Email = user.Email;
            UserName = user.UserName;

            
        }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "PWZNumber - only doctors")]
        public string PWZNumber { get; set; }

        [Display(Name = "Pesel number")]
        [ValidationPesel]
        public string PeselNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }


    }
}
