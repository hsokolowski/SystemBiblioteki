using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class BorrowingVM
    {
        public List<Borrowing> Get_list()
        {
            DB mDb = new DB();
            List<Borrowing> listaDB = mDb.Borrowings.ToList();
            return listaDB;
        }
        public void Dodaj(Borrowing u)
        {
            DB mDb = new DB();
            mDb.Borrowings.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(Borrowing a)
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

        public Borrowing Find(int id)
        {
            Borrowing u = new Borrowing();
            DB db = new DB();
            db.Borrowings.Attach(u);
            u = db.Borrowings.Find(id);
            return u;

        }
        public void Delete(int id)
        {
            DB db = new DB();
            Borrowing move = new Borrowing() { id_borrow = id };
            db.Borrowings.Attach(move);
            db.Borrowings.Remove(move);
            db.SaveChanges();

        }
    }
}