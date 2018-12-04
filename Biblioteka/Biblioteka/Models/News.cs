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
        public int NewsID { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Title { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Dodał")]
        public int AccountID { get; set; }
        public Account Account { get; set; }
        [Display(Name = "Treść")]
        public string Content { get; set; }
    }
}