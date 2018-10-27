using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Penalty
    {
        [Key]
        public int id_penalty { get; set; }

        [Display(Name = "Kwota")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int amount { get; set; }
    }
}