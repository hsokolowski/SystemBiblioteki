using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class AccountVM
    {
        public List<Account> Get_list()
        {
            DB mDb = new DB();
            List<Account> listaDB = mDb.Accounts.ToList();
            return listaDB;
        }
        public void Dodaj(Account u)
        {
            DB mDb = new DB();
            mDb.Accounts.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(Account a)
        {
            DB db = new DB();

            db.Entry(a).State = EntityState.Modified;
           
            try
            {
                db.SaveChanges();
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            //LayerBus.BusPass.EdytujFilm(a);
        }

        public Account Find(int id)
        {
            Account u = new Account();
            DB db = new DB();
            db.Accounts.Attach(u);
            u = db.Accounts.Find(id);
            return u;
            //return LayerBus.BusPass.ZnajdźFilm(id);
        }
        public void Delete(int id)
        {
            DB db = new DB();
            Account move = new Account() { AccountID = id };
            db.Accounts.Attach(move);
            db.Accounts.Remove(move);
            db.SaveChanges();
            //LayerBus.BusPass.UsuńFilm(id);
        }
    }
    
}