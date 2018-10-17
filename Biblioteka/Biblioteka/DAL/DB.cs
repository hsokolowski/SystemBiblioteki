using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.DAL
{
    public class DB : DbContext
    {
        public DB() : base("MyDB")
        {

        }
            public DbSet<Czytelnik> Czytelnicy { get; set; }
            public DbSet<Ksiazka> Ksiazki { get; set; }
            public DbSet<Pracownik> Pracownicy { get; set; }
            public DbSet<Kategoria> Kategorie { get; set; }
        
    }
}