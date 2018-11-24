using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class AuthorVM
    {
        public List<Author> Get_list()
        {
            DB mDb = new DB();
            List<Author> listaDB = mDb.Authors.ToList();
            return listaDB;
        }
        public void Dodaj(Author u)
        {
            DB mDb = new DB();
            mDb.Authors.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(Author a)
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

        public Author Find(int id)
        {
            Author u = new Author();
            DB db = new DB();
            db.Authors.Attach(u);
            u = db.Authors.Find(id);
            return u;
            
        }
        public void Delete(int id)
        {
            DB db = new DB();
            Author move = new Author() { AuthorID = id };
            db.Authors.Attach(move);
            db.Authors.Remove(move);
            db.SaveChanges();
         
        }
    }
}