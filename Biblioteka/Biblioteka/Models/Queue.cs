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
        
        public int QueueID { get; set; }

        [Display(Name = "ID Książki")]
        //[ForeignKey("Book")]
        public int BookID { get; set; }
        public Book Book { get; set; }
        [Display(Name = "Kolejka")]
        public int Order { get; set; }

        [Display(Name = "Czytelnik")]
        //[ForeignKey("Account")]
        public int AccountID { get; set; }
        public Account Account { get; set; }
    }
}