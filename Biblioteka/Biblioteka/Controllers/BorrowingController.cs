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

            foreach (var item in list_book)
            {
                var repo_book = repositories.ElementAt(item.BookID - 1);

                if (repo_book.Amount != 0)
                {
                    Borrowing b = new Borrowing
                    {
                        ReaderID = userId,
                        Borrow_date = DateTime.Now,
                        BookID = item.BookID,
                        PenaltyID = 1,
                        QueueID = 0

                    };
                    b.Return_date = b.Borrow_date.AddDays(30);
                    borrowingVM.Dodaj(b);
                    repositoryVM.Minus_amount(repo_book);
                   
                }
                else
                {
                    return View("Empty repository of this book");//trzeba zablokować możliwość wypożyczenia gdy nie jest dostępna
                }
            }
            return View("Success");
        }
    }
}