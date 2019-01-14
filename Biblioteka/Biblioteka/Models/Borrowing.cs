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
        public int BorrowID { get; set; }

        [Display(Name = "ID Czytelnik")]
        public int ReaderID { get; set; }

        [Display(Name = "Data wypożyczenia")]
        public DateTime Borrow_date { get; set; }


        [Display(Name = "Data zwrotu")]
        public DateTime Return_date { get; set; }

        [Display(Name = "Czy zwrócone")]
        public Boolean Returned { get; set; }

        [Display(Name = "Kara")]
        public int PenaltyID { get; set; }
        public Penalty Penalty { get; set; }

        //prawdopodobnie skasować
        [Display(Name = "Kolejka")]
        public int QueueID { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }

    }
}