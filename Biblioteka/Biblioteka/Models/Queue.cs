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
        public int QueueID { get; set; }

        [Display(Name = "ID Książki")]
        //[ForeignKey("Book")]
        public int BookID { get; set; }

        [Display(Name = "Kolejka")]
        public int Order { get; set; }

        [Display(Name = "Czytelnik")]
        //[ForeignKey("Account")]
        public int AcountID { get; set; }
    }
}