using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class GlobalV1
    {
        public IEnumerable<Biblioteka.Models.Book> book { get; set; }
        public IEnumerable<Biblioteka.Models.Author> auth { get; set; }
        public IEnumerable<Biblioteka.Models.Category> cate { get; set; }
    }
}