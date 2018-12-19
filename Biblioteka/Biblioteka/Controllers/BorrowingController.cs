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
        public ActionResult Borrow(int id)
        {
            BorrowingVM vm = new BorrowingVM();

            Borrowing b = new Borrowing();
            b.ReaderID = id;
            b.Borrow_date = DateTime.Now;
            // TODO zmienić pozniej na parametr ustawiany przez admina;
            b.Return_date = b.Borrow_date.AddDays(30);
            b.Books=(ICollection<Book>)Session["Zamowienie"];
            //b.Books = (ICollection<Book>)Session["Borrow"];
            //b.Books = (List<Book>)Session["Zamowienie"];

            //defaoltowo na 0
            b.PenaltyID = 0;
            b.QueueID = 0;
            vm.Dodaj(b);
            List<Borrowing> list = vm.Get_list();
            return View("Index", list);//była lista
        }
    }
}