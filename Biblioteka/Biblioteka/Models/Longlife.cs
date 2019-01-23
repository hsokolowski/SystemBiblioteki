using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Longlife
    {
        [Key]
        public int LonglifeID { get; set; }

        public int longlife { get; set; }
    }
}