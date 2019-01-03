using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class History
    {
        public int Id { get; set; }

        public string Search { get; set; }

        public DateTime SearchDate { get; set; }

        public int AccountID { get; set; }
        public Account Account { get; set; }
    }
}