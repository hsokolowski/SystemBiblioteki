using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class AutBook
    {
        [Key]
        public int AutBookID { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int AuthorID { get; set; }

        [Display(Name = "Książka")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int BookID { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}