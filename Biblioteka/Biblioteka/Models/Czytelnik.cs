using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Czytelnik
    {
        [Key]
        public int czytelnikID { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string imie_c { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string nazwisko_c { get; set; }

        [Display(Name = "Pesel")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string pesel_c { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!"), Display(Name = "E-mail"), EmailAddress]
        public string email_c { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string login_c { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć minimum {2} znaków", MinimumLength = 5)]
        public string password_c { get; set; }

        [Display(Name = "Potwierdź Hasło")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmedpassword_c { get; set; }
    }
}