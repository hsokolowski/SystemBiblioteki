using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Ksiazka
    {
        [Key]
        [Display(Name = "ID")]
        public int ksiazkaID { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string tytul { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public string autor { get; set; }

        [Display(Name = "Rok")]
        [Range(0, 99999, ErrorMessage = "Rok nie może być ujemny!")]
        public int rok { get; set; }

        [NotMapped]
        public Typ Type { get; set; }

        [Display(Name = "Kategoria")]
        public string TypeString
        {
            get
            {
                return Type.ToString();
            }
            private set
            {
                Type = value.ParseEnum<Typ>();
            }

        }

        [Display(Name = "Ilość stron")]
        [Required(ErrorMessage = "To pole jest wymagane!")]
        public int ilosc_str { get; set; }

        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [NotMapped]
        public Dlakogo from_who { get; set; }

        [Display(Name = "Przeznaczona")]
        public string dla_kogo
        {
            get
            {
                return from_who.ToString();
            }
            private set
            {
                from_who = value.ParseEnum<Dlakogo>();
            }

        }

        public string agecolor
        {
            get
            {
                if (dla_kogo =="Dzieci")
                {
                    return "green";
                }
                else if (dla_kogo=="Młodzież")
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
    public enum Dlakogo
    {
        Dzieci=1,
        Młodzież=2,
        Dorośli=3
    }
    public enum Typ
    {
        Horror = 1,
        Komedia = 2,
        Obyczajowy = 3,
        Thriller = 4,
        Romantyczny = 5,
        Dokumentalny = 6
    }
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}