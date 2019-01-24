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

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Nadrzędna1")]
        public virtual ICollection<SubCategory> SubCategories { get; set; }

       
        [Display(Name = "Nadrzędna")]
        public string SubCategs { get; set; }

    }
}