using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Author
    {
        [Key]
        public int id_author { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string surname { get; set; }

        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string country { get; set; }
    }
}