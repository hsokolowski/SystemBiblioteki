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
        public int TagID { get; set; }

        [Display(Name = "Tag")]
        [Required]
        public string Name { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }

    }
}