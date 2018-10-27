using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class News
    {
        [Key]
        public int id_news { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string title { get; set; }

        [Display(Name = "Data")]
        public DateTime date { get; set; }

        [Display(Name = "Dodał")]
        public int id_employer { get; set; }

        [Display(Name = "Treść")]
        public string content { get; set; }
    }
}