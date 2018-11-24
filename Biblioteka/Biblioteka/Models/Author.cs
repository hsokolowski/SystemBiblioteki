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
        public int AuthorID { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Surname { get; set; }

        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Country { get; set; }

        public virtual ICollection<AutBook> AutBooks { get; set; }
    }
}