using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class FileBook
    {
        [Key]
        public int id_file { get; set; }

        public string name { get; set; }

        public string stream { get; set; }

        public int id_book { get; set; }
    }
}