using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class NewsVM
    {
        public List<News> Get_list()
        {
            DB mDb = new DB();
            List<News> listaDB = mDb.News.ToList();
            return listaDB;
        }
        public void Dodaj(News u)
        {
            DB mDb = new DB();
            mDb.News.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(News a)
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

        public News Find(int id)
        {
            News u = new News();
            DB db = new DB();
            db.News.Attach(u);
            u = db.News.Find(id);
            return u;
        }
        public void Delete(int id)
        {
            DB db = new DB();
            News move = new News() { id_news = id };
            db.News.Attach(move);
            db.News.Remove(move);
            db.SaveChanges();
        }
    }
}