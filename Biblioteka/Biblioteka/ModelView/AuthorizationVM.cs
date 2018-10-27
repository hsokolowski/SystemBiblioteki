using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class AuthorizationVM
    {
        public List<Account> Get_list()
        {
            DB mDb = new DB();
            List<Account> listaDB = mDb.Accounts.ToList();
            return listaDB;
        }
    }
}