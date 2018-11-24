using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class PenaltyVM
    {
        public List<Penalty> Get_list()
        {
            DB mDb = new DB();
            List<Penalty> listaDB = mDb.Penalties.ToList();
            return listaDB;
        }
        public void Dodaj(Penalty u)
        {
            DB mDb = new DB();
            mDb.Penalties.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(Penalty a)
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

        public Penalty Find(int id)
        {
            Penalty u = new Penalty();
            DB db = new DB();
            db.Penalties.Attach(u);
            u = db.Penalties.Find(id);
            return u;
        }
        public void Delete(int id)
        {
            DB db = new DB();
            Penalty move = new Penalty() { PenaltyID = id };
            db.Penalties.Attach(move);
            db.Penalties.Remove(move);
            db.SaveChanges();
        }
    }
}