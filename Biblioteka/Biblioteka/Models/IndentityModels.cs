using Biblioteka.App_Start;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class ApplicationUser : IdentityUser
    {

        public virtual MyUserInfo UserInfo { get; set; }


    }


    public class MyUserInfo
    {
        public int MyUserInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

}