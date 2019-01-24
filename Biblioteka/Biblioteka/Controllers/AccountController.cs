using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            AccountVM userBL = new AccountVM();
            List<Account> list = userBL.Get_list();
            return View(list);
        }
        public ActionResult Add(int id = 0)
        {
            Account a = new Account();
            return View(a);
        }
        [HttpPost]
        public ActionResult Add(Account p)
        {
            AccountVM userBL = new AccountVM();
            List<Account> list = userBL.Get_list();

            if (list.Any(x => x.Login == p.Login))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("Add", p);
                //o co chodzi co ma być w account?
            }

            userBL.Dodaj(p);
            ViewBag.Succesmessage = "Rejestracja pomyślna!";
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AccountVM vm = new AccountVM();
            List<Account> lista = vm.Get_list();
            Account a = lista.Where(s => s.AccountID == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account m)
        {
            AccountVM vm = new AccountVM();
            vm.Update(m);
            ViewBag.Succesmessage = "Edycja pomyślna!";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            AccountVM vm = new AccountVM();
            Account u = vm.Find(id);
            return View(u);
        }
        public ActionResult Delete(int id) //dodać w widoku edit
        {
            AccountVM vm = new AccountVM();
            vm.Delete(id);
            return RedirectToAction("Index");
        }
    }
}