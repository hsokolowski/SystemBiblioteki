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
        [Key]
        public int RepositoryID { get; set; }

        [Display(Name = "ISBN")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public int ISBN { get; set; }

        [Display(Name = "ID Książki")]
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}