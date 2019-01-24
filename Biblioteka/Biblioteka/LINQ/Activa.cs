using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteka.LINQ
{
    public class Activa
    {
        public List<Account> accs { get; set; }
    }
}