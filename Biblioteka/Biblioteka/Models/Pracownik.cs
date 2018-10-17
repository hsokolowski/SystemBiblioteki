using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Pracownik
    {
        [Key]
        public int pracownikID { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string imie_p { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string nazwisko_p { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!"), Display(Name = "E-mail"), EmailAddress]
        public string email_p { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string login_p { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć minimum {2} znaków", MinimumLength = 5)]
        public string password_p { get; set; }

        [Display(Name = "Potwierdź Hasło")]
        [DataType(DataType.Password)]
        [Compare("password_p")]
        public string confirmedpassword_p { get; set; }
    }
}