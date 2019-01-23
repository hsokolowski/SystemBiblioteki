using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class TagBook
    {
        [Key]
        public int TagBookID { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int TagID { get; set; }

        [Display(Name = "Książka")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int BookID { get; set; }


        public virtual Tag Tag { get; set; }
        public virtual Book Book { get; set; }

    }
}