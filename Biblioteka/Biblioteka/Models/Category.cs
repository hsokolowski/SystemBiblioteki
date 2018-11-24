using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Display(Name ="Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Kat. nadrzędna")]
        public int id_father { get; set; }
    }
}