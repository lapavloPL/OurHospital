using DataLibrary.Validations;
using OurHospital.Models;
using OurHospital.ViewUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurHospital.Controllers
{
    public class ManageUserController : Controller
    {
        private ApplicationDbContext context;

        public ManageUserController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Firstname = user.FirstName,
                                      Lastname = user.LastName,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UserListModel()

                                  {
                                      UserId = p.UserId,
                                      FirstName = p.Firstname,
                                      LastName = p.Lastname,
                                      UserName = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }
    }
}