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
        public int BookID { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string Title { get; set; }

        //[Display(Name = "Autor")]
        //[ForeignKey("Author")]
        //[Required(ErrorMessage = "To pole jest wymagane!")]
        //public int AuthorID { get; set; }

        [Display(Name = "Rok")]
        [Range(0, 99999, ErrorMessage = "Rok nie może być ujemny!")]
        public int Year { get; set; }

        [Display(Name = "Kategoria")]
        public int CategoryID { get; set; }

        [Display(Name = "Ilość stron")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int Pages { get; set; }

        [Display(Name = "Numer ISBN")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int ISBN { get; set; }

        [NotMapped]
        public Forwho For_who { get; set; }


        public virtual ICollection<AutBook> AutBooks { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Queue> Queues { get; set; }

        public virtual Repository Repository { get; set; }

        [Display(Name = "Przeznaczona:")]
        public string for_who_string
        {
            get
            {
                return For_who.ToString();
            }
            private set
            {
                For_who = value.ParseEnum<Forwho>();
            }

        }
       
        public string agecolor
        {
            get
            {
                if (for_who_string == "Dzieci")
                {
                    return "green";
                }
                else if (for_who_string == "Młodzież")
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