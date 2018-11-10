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
        public List<Position> Get_list()
        {
            DB mDb = new DB();
            List<Position> listaDB = mDb.Positions.ToList();
            return listaDB;
        }
        public void Dodaj(Position u)
        {
            DB mDb = new DB();
            mDb.Positions.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
        public void Update(Position a)
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

        public Position Find(int id)
        {
            Position u = new Position();
            DB db = new DB();
            db.Positions.Attach(u);
            u = db.Positions.Find(id);
            return u;
        }
        public void Delete(int id)
        {
            DB db = new DB();
            Position move = new Position() { id_position = id };
            db.Positions.Attach(move);
            db.Positions.Remove(move);
            db.SaveChanges();
        }
    }
}