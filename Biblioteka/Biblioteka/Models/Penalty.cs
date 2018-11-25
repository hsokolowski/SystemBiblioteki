using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Penalty
    {
        
        public int PenaltyID { get; set; }

        [Display(Name = "Kwota")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int Value { get; set; }
        public int Days { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}