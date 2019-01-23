using Biblioteka.DAL;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class BorrowingController : Controller
    {
        // GET: Borrowing
        public ActionResult Index()
        {
            BorrowingVM vm = new BorrowingVM();
            return View(vm.Get_list());
        }


        


        public ActionResult Borrow()
        {
            BorrowingVM borrowingVM = new BorrowingVM();        
            RepositoryVM repositoryVM = new RepositoryVM();
            var repositories =  repositoryVM.Get_list();
            var list_book = Session["Zamowienie"] as IEnumerable<Biblioteka.Models.Book>;
            var userId = (Int32)(Session["adminID"]);
            if (list_book!=null)
            {
                DB db = new DB();
                Longlife l = db.Longlifes.Where(x => x.LonglifeID == 1).FirstOrDefault();
                int days = l.longlife;
                foreach (var item in list_book)
                {
                    Repository repo_book = repositories.Where(a => a.RepositoryID == item.Repository.RepositoryID).FirstOrDefault();

                    if (repo_book.Amount != 0)
                    {
                        Borrowing b = new Borrowing
                        {
                            ReaderID = userId,
                            Borrow_date = DateTime.Now,
                            BookID = item.BookID,
                            PenaltyID = 1,
                            Returned = false,
                            QueueID = 0
                        };
                        b.Return_date = b.Borrow_date.AddDays(days);
                        borrowingVM.Dodaj(b);
                        repositoryVM.Minus_amount(repo_book);
                        Session["Zamowienie"] = null;
                    }
                    else
                    {
                        return RedirectToAction("Borrow_failed");//trzeba zablokować możliwość wypożyczenia gdy nie jest dostępna
                    }
                }
                return View("Borrow_success");
            }
            return View();
        }
        [Authorize]
        public ActionResult Archiwum()
        {
            var userId = (Int32)(Session["adminID"]);

            BorrowingVM vm = new BorrowingVM();
            BookVM bo = new BookVM();

            var list = from b in vm.Get_list()
                       join k in bo.Get_list() on b.BookID equals k.BookID
                       where b.ReaderID == userId
                       orderby b.BorrowID descending
                       select new
                       {
                           b.BorrowID,
                           b.Borrow_date,
                           b.Return_date,
                           b.Returned,
                           k.Title
                       };
            if (list == null)
            {
                ViewBag.Archiwum = "Nic jeszcze nie zostało wypożyczone."; // TODO odsłużyć w widoku + wyświetlanie listy
            }

            return View(list);
        }

    }
}