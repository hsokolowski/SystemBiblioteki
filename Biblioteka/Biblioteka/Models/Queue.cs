using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Queue
    {
        [Key]
        public int id_queue { get; set; }

        [Display(Name = "ID Książki")]
        //[ForeignKey("Book")]
        public int id_book { get; set; }

        [Display(Name = "Kolejka")]
        public int queue { get; set; }

        [Display(Name = "Czytelnik")]
        //[ForeignKey("Account")]
        public int id_reader { get; set; }
    }
}