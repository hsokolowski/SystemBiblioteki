using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Biblioteka.ModelView
{
    public class AuthorizationVM:System.Web.UI.Page
    {
        public List<Account> Get_list()
        {
            DB mDb = new DB();
            List<Account> listaDB = mDb.Accounts.ToList();
            return listaDB;
        }
        public bool IsAdmin(Account a)
        {
            if (a.Login == "admin" && a.Password == "admin" && a.Role.ToString()=="Admin")
            {
                return true;
            }
            return false;
        }

        private string[] baseRole = { "Admin", "Worker","Reader" };
        public bool isValidUser(string userName, string password, Role r)
        {
            if ((userName == "admin") && (password == "admin") )
            {
                string[] role = { baseRole[0] };
                AuthenticateUserAndRole("admin", role);
                User.IsInRole("Admin");
                return true;
            }
            else if (r.ToString() == "Worker")
            {
                string[] role = { baseRole[1] };
                AuthenticateUserAndRole(userName, role);
                User.IsInRole("Worker");
                return true;
            }
            else if((r.ToString() == "Reader"))
            {
                string[] role = { baseRole[2] };
                AuthenticateUserAndRole(userName, role);
                User.IsInRole("Reader");
                return true;
            }
            return false;
        }
        private void AuthenticateUserAndRole(string userName, string[] roles)
        {
            GenericIdentity userIdentity = new GenericIdentity(userName);
            GenericPrincipal userPrincipal =
                new GenericPrincipal(userIdentity, roles);
            Context.User = userPrincipal;
        }
    }
}