using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class BookVM
    {
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
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
    }
}