using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OurHospital.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z_]*$", ErrorMessage = "Accept only letters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name: ")]
        [RegularExpression(@"^[a-zA-Z_]*$", ErrorMessage = "Accept only letters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "PESEL Number: ")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Accept only numbers.")]
        public string PeselNumber { get; set; }

        [Display(Name = "PWZ Number: ")]
        public string PWZNumber { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole 
    { 
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<OurHospital.ViewUsers.UserListModel> UserListModels { get; set; }
    }
}