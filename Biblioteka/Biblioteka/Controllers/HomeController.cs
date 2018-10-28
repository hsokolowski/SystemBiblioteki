﻿using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static Biblioteka.Models.CustomAuthorizeAttribute;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AccountVM vm = new AccountVM();
            List<Account> lista = vm.Get_list();
            
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
        
        public ActionResult Konto(int id = 0)
        {
            Account a = new Account();
            return View(a);
        }
        [HttpPost]
        public ActionResult Konto(Account p)
        {
            AccountVM userBL = new AccountVM();
            List<Account> list = userBL.Get_list();

            if (list.Any(x => x.login == p.login))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("Account", p);
            }

            userBL.Dodaj(p);
            ViewBag.Succesmessage = "Rejestracja pomyślna!";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            AccountVM vm = new AccountVM();
            List<Account> lista = vm.Get_list();
            Account a= lista.Where(s => s.id_account == id).FirstOrDefault();
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
        public ActionResult Delete(int id)
        {
            AccountVM vm = new AccountVM();
            vm.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account user, string ReturnUrl)  //Autoryzacja Logownie
        {
            var url = ViewBag.ReturnUrl;
            AuthorizationVM avm = new AuthorizationVM();
            using (DAL.DB db = new DAL.DB())
            {
                //var tym = Encrypt.GetHash(user.password);
                var userdeatils = db.Accounts.Where(x => x.login == user.login && x.password == user.password).FirstOrDefault();
                if (userdeatils == null)
                {
                    ViewBag.LoginErrorMessage = "Nie poprawny login lub hasło";
                    return View("Login", user);
                }
                else
                {
                    if(userdeatils.activ==false)
                    {
                        ViewBag.LoginErrorMessage = "Konto nie aktywowane";
                        return View("Login", user);
                    }
                    Session["adminID"] = userdeatils.id_account;
                    Session["login"] = userdeatils.login;
                    FormsAuthentication.SetAuthCookie(user.login, false);
                    //return Redirect(ReturnUrl);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        public ActionResult Logout()
        {
            int userid = (int)Session["adminID"];
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            
            return View();
        }
        
        public ActionResult Dodaj_kategorie(int id = 0)
        {
            Category c = new Category();
            return View(c);
        }
        [HttpPost]
        public ActionResult Dodaj_kategorie(Category c)
        {
            CategoryVM vm = new CategoryVM();
            List<Category> list = vm.Get_list();

            if (list.Any(x => x.name==c.name))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("Dodaj_kategorie", c);
            }
            vm.Dodaj(c);
            return RedirectToAction("Index");
        }
        public ActionResult Kategorie()
        {
            CategoryVM cvm = new CategoryVM();
            List<Category> lista2 = cvm.Get_list();
            return View(lista2);
        }
        public ActionResult Ksiazki()
        {
            BookVM vm = new BookVM();
            List<Book> lista2 = vm.Get_list();
            return View(lista2);
        }


    }
}