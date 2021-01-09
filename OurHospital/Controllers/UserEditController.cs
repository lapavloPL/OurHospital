using DataLibrary.Validations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OurHospital.Models;
using OurHospital.ViewUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OurHospital.Controllers
{
    public class UserEditController : Controller
    {
        private ApplicationUserManager _userManager;

        public UserEditController()
        {
            context = new ApplicationDbContext();
 
        }

        public UserEditController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationDbContext context;

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(context.Users.ToList());
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(string email)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser = UserManager.FindByEmail(email);
            UserEdit user = new UserEdit();
            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.PeselNumber = appUser.PeselNumber;
            user.PWZNumber = appUser.PWZNumber;
            user.UserName = appUser.UserName;
            user.Email = appUser.Email;

            return View(user);
        }

        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(UserEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindByEmail(model.Email);
            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.PeselNumber = model.PeselNumber;
            currentUser.UserName = model.UserName;
            currentUser.Email = model.Email;
            
            await manager.UpdateAsync(currentUser);
            var ctx = store.Context;
            ctx.SaveChanges();
            TempData["msg"] = "Profile Changes Saved !";
            return RedirectToAction("List");
        }

        [CustomAuthorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["UserDeleted"] = "User Successfully Deleted";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UserDeleted"] = "Error Deleting User";
                return RedirectToAction("List");
            }
        }
    }
}