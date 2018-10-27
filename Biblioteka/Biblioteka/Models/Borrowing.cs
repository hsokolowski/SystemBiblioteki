using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Borrowing
    {
        [Key]
        public int id_borrow { get; set; }

        [Display(Name = "ID Czytelnik")]
        public int id_reader { get; set; }

        [Display(Name = "ID Książka")]
        public int id_book { get; set; }

        [Display(Name = "Data wypożyczenia")]
        public DateTime date_borrow { get; set; }


        [Display(Name = "Data zwrotu")]
        public DateTime date_back { get; set; }

        [Display(Name = "Kara")]
        public int id_penalty { get; set; }

    }
}