using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Repository
    {
        
       // public int RepositoryID { get; set; }

        [Display(Name = "ISBN")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public int ISBN { get; set; }
        public int Amount { get; set; }
        [ForeignKey("Book")]
        [Display(Name = "ID Książki")]
        public int RepositoryID { get; set; }
        public virtual Book Book { get; set; }

    }
}