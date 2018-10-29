using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
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
    }
}