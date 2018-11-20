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
        public int id_category { get; set; }

        [Display(Name ="Nazwa")]
        public string name { get; set; }

        [Display(Name = "Kat. nadrzędna")]
        public int id_father { get; set; }
    }
}