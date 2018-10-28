using Biblioteka.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Account
    {
        [Key]
        public int id_account { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string surname { get; set; }

        [Display(Name = "Pesel")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        //[IsPesel]
        [StringLength(11, ErrorMessage = "Pole musi mieć 11 znaków")]
        public string pesel { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane!"), Display(Name = "E-mail"), EmailAddress]
        public string email { get; set; }

        [Display(Name = "Czy aktywne?")]
        public bool activ { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string login { get; set; }

        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć minimum {2} znaków", MinimumLength = 3)]
        public string password { get; set; }

        [Display(Name = "Potwierdź Hasło")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmedpassword { get; set; }

        //[NotMapped]
        [Display(Name = "Rola")]
        public Role role { get; set; }

        //[Display(Name = "Rola")]
        //public string TypeString {
        //    get
        //    {
        //        return Type.ToString();
        //    }
        //    private set
        //    {
        //        Type = value.ParseEnum<Role>();
        //    }
        //}
    }
    public enum Role
    {
        Admin=1,
        Reader=2,
        Worker =3
    }
    //public static class StringExtensions
    //{
    //    public static T ParseEnum<T>(this string value)
    //    {
    //        return (T)Enum.Parse(typeof(T), value, true);
    //    }
    //}
}