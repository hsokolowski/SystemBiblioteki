using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class PositionVM
    {
        public List<Repository> Get_list()
        {
            DB mDb = new DB();
            List<Repository> listaDB = mDb.Repositories.ToList();
            return listaDB;
        }
        public void Dodaj(Repository u)
        {
            DB mDb = new DB();
            mDb.Repositories.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(Repository a)
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
        }

        public Repository Find(int id)
        {
            Repository u = new Repository();
            DB db = new DB();
            db.Repositories.Attach(u);
            u = db.Repositories.Find(id);
            return u;
        }
        public void Delete(int id)
        {
            DB db = new DB();
            Repository move = new Repository() { RepositoryID = id };
            db.Repositories.Attach(move);
            db.Repositories.Remove(move);
            db.SaveChanges();
        }
    }
}