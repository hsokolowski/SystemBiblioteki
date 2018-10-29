using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Biblioteka.Models
{
    public class AppAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //#region Properties

        //Enums.Acces[] RequestedAcces { get; set; }

        //#endregion

        //#region Constructors
        //public AppAuthorizeAttribute(params Enums.Acces[] acces)
        //{
        //    this.RequestedAcces = acces;
        //}

        //#endregion

        //#region Public

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
        //}

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (httpContext == null)
        //    {
        //        throw new ArgumentNullException("httpContext");
        //    }
        //    if (CurrentUser.Model.IsAdmin) return true;

        //    foreach (Enums.Acces acces in RequestedAcces)
        //    {
        //        switch (acces)
        //        {
        //            case Enums.Acces.Active:
        //                if (CurrentUser.Model.IsActiv) return true;
        //                break;
        //            case Enums.Acces.All:
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        //#endregion
    }

}