using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class CategoryVM
    {
        public List<Category> Get_list()
        {
            DB mDb = new DB();
            List<Category> listaDB = mDb.Categories.ToList();
            return listaDB;
        }
        public void Dodaj(Category u)
        {
            DB mDb = new DB();
            mDb.Categories.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
    }
}