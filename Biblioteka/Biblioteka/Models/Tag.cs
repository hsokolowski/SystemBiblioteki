using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Tag
    {
        [Key]
        public string id_tag { get; set; }

        [Display(Name = "Tag")]
        [Required]
        public string tag { get; set; }

        [Required]
        [Display(Name ="ID Książki")]
        public int id_book { get; set; }

    }
}