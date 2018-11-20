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
        public int id { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int id_author { get; set; }

        [Display(Name = "Książka")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int id_book { get; set; }

       
    }
}