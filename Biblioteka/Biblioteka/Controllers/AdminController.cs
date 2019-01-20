using Biblioteka.CustomFilters;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    [AdminRole]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [AdminRole]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult SendMails()
        {
            GMailer.GmailUsername = "panmail1212p@gmail.com";
            GMailer.GmailPassword = "zaq1@wsx";

            AccountVM acc = new AccountVM();
            BorrowingVM vm = new BorrowingVM();
            var licznik1 = 0;
            GMailer mailer = new GMailer();
            foreach (var a in vm.Get_list())
            {
                if (a.Returned == false)
                {
                    if (a.Return_date < DateTime.Now)
                    {
                        foreach (var b in acc.Get_list())
                        {
                            if (b.AccountID == a.ReaderID)
                            {
                                licznik1++;
                                mailer.ToEmail = b.Email;
                                mailer.Subject = "Zwrot";
                                mailer.Body = "Prosimy o zwrot książki!";
                                mailer.IsHtml = true;
                                mailer.Send();
                                break;
                            }
                        }
                    }
                }
            }
            ViewBag.Mails1 = "Wysłano próśb " + licznik1;

            var licznik2 = 0;
            foreach (var a in vm.Get_list())
            {
                if (a.Returned == false)
                {
                    if (a.Return_date.Date == DateTime.Now.Date.AddDays(1))
                    {
                        foreach (var b in acc.Get_list())
                        {
                            if (b.AccountID == a.ReaderID)
                            {
                                licznik2++;
                                mailer.ToEmail = b.Email;
                                mailer.Subject = "Przypomnienie";
                                mailer.Body = "Został Tobie dzień na zwrot książki!";
                                mailer.IsHtml = true;
                                mailer.Send();
                            }
                        }
                    }
                }
            }
            ViewBag.Mails2 = "Wysłano przypomnień " + licznik2;


            return View("Admin");
        }
    }
}