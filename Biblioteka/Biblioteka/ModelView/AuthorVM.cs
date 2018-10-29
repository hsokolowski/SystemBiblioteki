using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
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
    }
}