using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PracownikADD vm = new PracownikADD();
            List<Pracownik> lista = vm.GetList();
            return View(lista);
        }
        public ActionResult Lista()
        {
            return View();
        }
        public ActionResult Koszyk()
        {
            return View();
        }
        
        public ActionResult Pracownik(int id = 0)
        {
            Pracownik a = new Pracownik();
            return View(a);
        }
        [HttpPost]
        public ActionResult Pracownik(Pracownik p)
        {
            PracownikADD userBL = new PracownikADD();
            List<Pracownik> list = userBL.GetList();
            if (list.Any(x => x.login_p == p.login_p))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("Pracownik", p);
            }

            userBL.Dodaj(p);
            ViewBag.Succesmessage = "Rejestracja pomyślna!";
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult AdminAdd(int id = 0)
        //{
        //    Admin a = new Admin();
        //    return View(a);
        //}
        //[HttpPost]
        //public ActionResult AdminAdd(Admin b)
        //{
        //    Admin a = new Admin();
        //    AdminAdd ad = new ViewModels.AdminAdd();
        //    a = b;
        //    List<Admin> list = ad.GetAdmins();
        //    if (list.Any(x => x.login == b.login))
        //    {
        //        ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
        //        return View("AdminAdd", b);
        //    }
        //    a.password = Encrypt.GetHash(a.password);
        //    ad.AddUser(a);
        //    ViewBag.Succesmessage = "Rejestracja pomyślna!";
        //    return View("AdminAdd", new Admin());
        //}
    }
}