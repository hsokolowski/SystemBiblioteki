using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class File
    {
        
        public int FileID { get; set; }

        public string Name { get; set; }

        public string Stream { get; set; }

        public int BookID { get; set; }
    }
}