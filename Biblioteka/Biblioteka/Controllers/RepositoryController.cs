using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class RepositoryController : Controller
    {
        // GET: Repository
        public ActionResult Index()
        {
            return View();
        }
    }
}