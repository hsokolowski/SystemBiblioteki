using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class Autors_books
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
         public IEnumerable<Autors_books2> Authors { get; set; }

        public class Autors_books2
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public IEnumerable<Autors_books> Books { get; set; }
        }
    }


}