using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class BookVM
    {
        public DB DB()
        {
            DB dB = new DB();
            return dB;
        }
        public List<Book> Get_list()
        {
            DB mDb = new DB();
            List<Book> listaDB = mDb.Books.ToList();
            return listaDB;
        }
        public void Dodaj(Book u)
        {
            DB mDb = new DB();
            mDb.Books.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            mDb.SaveChanges();
        }
        public void Update(Book a)
        {
            DB db = new DB();

            db.Entry(a).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        public Book Find(int id)
        {
            Book u = new Book();
            DB db = new DB();
            db.Books.Attach(u);
            u = db.Books.Find(id);
            return u;
        }
        public void Delete(int id)
        {
            DB db = new DB();
            Book move = new Book() { BookID = id };
            //Trzeba kasować repo razem z książką bo jest relacja 1do1
          //  Repository repository = new Repository() { Book = move };
            db.Books.Attach(move);
            db.Books.Remove(move);
            //db.Repositories.Remove(repository);
            db.SaveChanges();
        }
    }
}