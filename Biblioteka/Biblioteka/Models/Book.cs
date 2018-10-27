using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Book
    {
        [Key]
        [Display(Name = "ID")]
        public int id_book { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string title { get; set; }

        [Display(Name = "Autor")]
        //[ForeignKey("Author")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        public int id_author { get; set; }

        [Display(Name = "Rok")]
        [Range(0, 99999, ErrorMessage = "Rok nie może być ujemny!")]
        public int year { get; set; }

        [Display(Name = "Kategoria")]
        public int id_category
        {
            get;set;

        }

        [Display(Name = "Ilość stron")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int ilosc_str { get; set; }

        [Display(Name = "Numer ISBN")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int ISBN { get; set; }

        [NotMapped]
        public Forwho from_who { get; set; }

        [Display(Name = "Przeznaczona")]
        public string for_who
        {
            get
            {
                return from_who.ToString();
            }
            private set
            {
                from_who = value.ParseEnum<Forwho>();
            }

        }
       
        public string agecolor
        {
            get
            {
                if (for_who == "Dzieci")
                {
                    return "green";
                }
                else if (for_who == "Młodzież")
                {
                    return "orange";
                }
                else
                {
                    return "red";
                }
            }
        }
    }
    public enum Forwho
    {
        Dzieci = 1,
        Młodzież = 2,
        Dorośli = 3,
    }
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}