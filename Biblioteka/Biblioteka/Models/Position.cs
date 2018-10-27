using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Position
    {
        [Key]
        public int id_position { get; set; }

        [Display(Name = "ISBN")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public int ISBN { get; set; }

        [Display(Name = "ID Książki")]
        public int id_book { get; set; }
    }
}