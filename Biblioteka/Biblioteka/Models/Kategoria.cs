using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Kategoria
    {
        [Key]
        public int katid { get; set; }

        public string kategoria { get; set; }
        //    [NotMapped]
        //    public Typ Type { get; set; }

        //    [Display(Name = "Kategoria")]
        //    public string TypeString
        //    {
        //        get
        //        {
        //            return Type.ToString();
        //        }
        //        private set
        //        {
        //            Type = value.ParseEnum<Typ>();
        //        }
        //    }
    }
    //public enum Typ
    //{
    //    Horror = 1,
    //    Komedia = 2,
    //    Obyczajowy = 3,
    //    Thriller = 4,
    //    Romantyczny = 5,
    //    Dokumentalny = 6
    //}
    //public static class StringExtensions
    //{
    //    public static T ParseEnum<T>(this string value)
    //    {
    //        return (T)Enum.Parse(typeof(T), value, true);
    //    }
    //}
}