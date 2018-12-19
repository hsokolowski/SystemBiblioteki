using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Kat. nadrzędna")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        
    }
}