using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.ModelView
{
    public class Your_borrow
    {
        public DateTime Borrow_date { get; set; }
        public DateTime Return_date { get; set; }
        public bool Returned { get; set; }
        public string Title { get; set; }
    }
}