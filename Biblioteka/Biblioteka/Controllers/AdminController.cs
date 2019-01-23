using Biblioteka.CustomFilters;
using Biblioteka.DAL;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mail;
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
            DB db = new DB();
            if(!db.Longlifes.Any())
            {
                ViewBag.Longlife = "Długość wypożyczenia: " + db.Longlifes.OrderByDescending(o => o.LonglifeID).FirstOrDefault();
            }
            
            


            return View();
        }
        [AdminRole]
        [HttpPost]
        public ActionResult Admin(FormCollection form)
        {
            string value = Convert.ToString(form["inputName"]);
             DB db = new DB();
            //ViewBag.Longlife = "Długość wypożyczenia: " + db.Longlifes.Last();
            if(value!=null&&value!="")
            {
                int days = Int32.Parse(value);

                Longlife l = db.Longlifes.Where(x => x.LonglifeID == 1).FirstOrDefault();
                l.longlife = days;
                db.Entry(l).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Longlife = "Długość wypożyczenia została ustawiona na: " + days +" dni!";
            }


            return View();
        }
       
        public async Task<ActionResult> SendMails()
        {
            AccountVM acc = new AccountVM();
            BorrowingVM bor = new BorrowingVM();
            BookVM book = new BookVM();
            
            List<Book> books = await Task.Run(() => book.Get_list());
            List<Account> accounts = await Task.Run(() => acc.Get_list());
            List<Borrowing> borrows = await Task.Run(() => bor.Get_list());
          
            var emails = from b in  books
                         from o in borrows
                         from a in accounts
                         where o.BookID==b.BookID && a.AccountID==o.ReaderID && o.Returned==false && o.Return_date < DateTime.Now
                         select new 
                         {
                             a.Email,
                             b.Title
                         };
           
            GMailer.GmailUsername = "panmail1212p@gmail.com";
            GMailer.GmailPassword = "zaq1@wsx";
            GMailer mailer = new GMailer();
           

            Parallel.ForEach(emails,  e =>
            {
        
                mailer.ToEmail = e.Email;
                mailer.Subject = "BIBLIOTEKA - Zwrot książki";
                mailer.Body = "Prosimy o zwrot książki '" + e.Title + "' !";
                mailer.IsHtml = true;
                mailer.Send();
            });
            ViewBag.Mails1 = "Wysłano próśb " + emails.Count();

            var emails1 = from b in books
                          from o in borrows
                          from a in accounts
                          where o.BookID == b.BookID && a.AccountID == o.ReaderID && o.Returned == false  && o.Return_date.Date == DateTime.Now.Date.AddDays(1)
                          select new
                         {
                             a.Email,
                             b.Title
                         };
           
            Parallel.ForEach(emails, e =>
            {
                mailer.ToEmail = e.Email;
                mailer.Subject = "BIBLIOTEKA - Przypomnienie o zwrocie książki!";
                mailer.Body = "Został jeden dzień do zwrotu książki '" + e.Title + "' ! Po upływie czasu kara zastanie naliczona!";
                mailer.IsHtml = true;
                mailer.Send();
            });

            ViewBag.Mails2 = "Wysłano przypomnień " + emails1.Count();
            
            return View("Admin");
        }
        
    }
}