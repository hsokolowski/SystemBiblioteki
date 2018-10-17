using Biblioteka.DAL;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class PracownikADD
    {
        public List<Pracownik> GetList()
        {
            DB mDb = new DB();
            List<Pracownik> listaDB = mDb.Pracownicy.ToList();
            return listaDB;
        }
        public void Dodaj(Pracownik u)
        {
            DB mDb = new DB(); 
            mDb.Pracownicy.Add(u);
            mDb.Configuration.ValidateOnSaveEnabled = false;
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
    }
}