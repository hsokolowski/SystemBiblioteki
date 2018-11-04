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
        public DB baza()
        {
            DB dB = new DB();
            

            //string query = "SELECT * FROM AUTHOR A "
            //    + "JOIN BOOK B ON A.ID_AUTHOR=B.ID_AUTHOR"
            //    + "JOIN CATEGORIES C ON B.ID_CATEGORY=C.ID_CATEGORY";

            //IEnumerable<EnrollmentDateGroup> data = dB.Database.SqlQuery<EnrollmentDateGroup>(query);

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
            //LayerBus.BusPass.DodajFilm(u);
            mDb.SaveChanges();
        }
    }
}