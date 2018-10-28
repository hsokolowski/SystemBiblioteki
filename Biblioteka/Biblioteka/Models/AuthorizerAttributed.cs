using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Models
{
    public class AuthorizerAttributed : AuthorizeAttribute
    {
        private readonly string userRole;

        public AuthorizerAttributed(string userRole)
        {
            this.userRole = userRole;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) // metoda, przy pomocy której udzielamy dostępu do akcji bądź nie
        {
            List<IdentityRole> roles = new List<IdentityRole>();

            if (httpContext.User.IsInRole(userRole)) // sprawdzamy, czy aktualny user jest piekarzem
            {
                return true; // jeśli tak - uzyskuje on dostęp do akcji BakeBread
            }

            return false; // jeśli nie, błąd 401 - nieuprawnionym wstęp wzbroniony
        }
    }
}