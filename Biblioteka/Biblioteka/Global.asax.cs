using Biblioteka.App_Start;
using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Biblioteka
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //using (var db = new DB())
            //{
            //    db.Database.SetInitializer(new Initial());
            //    db.Database.Initialize(true);
            //}
            Database.SetInitializer<ApplicationDbContext>(new IdentityDbInitializer());
        }
    }
}
