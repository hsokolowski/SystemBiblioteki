using Biblioteka.DAL;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Biblioteka.CustomFilters
{
    
        public class AdminRole : ActionFilterAttribute, IActionFilter
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
            }

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                DB db = new DB();
                AccountVM vm = new AccountVM();
                List<Account> userList;
                userList = vm.Get_list().Where(r => r.Role == Role.Admin).ToList();

                if (!userList.Any(u => u.Login == filterContext.HttpContext.User.Identity.Name))
                {
                    //filterContext.Controller.TempData["Message"] = "Zaloguj się na konto z odpowiednimi uprawnieniami by poznać sekret ;) ";
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }

        }
    
}