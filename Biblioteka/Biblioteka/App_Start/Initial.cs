using Biblioteka.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Biblioteka.Models;

namespace Biblioteka.App_Start
{
    public class IdentityDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var myinfo = new MyUserInfo() { FirstName = "Jan", LastName = "Kowalski" };
            string roleName = "Admin";
            string password = "admin";

            UserManager.Create(new ApplicationUser() { UserName = "Kazio", UserInfo = myinfo }, password);

            if (!RoleManager.RoleExists(roleName))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleName));
            }

            var user = new ApplicationUser();
            user.UserName = "admin";
            user.UserInfo = myinfo;
            var createResult = UserManager.Create(user, password);

         

            if (createResult.Succeeded)
            {
                var result = UserManager.AddToRole(user.UserName, roleName);
            }

            base.Seed(context);
        }
    }
}
