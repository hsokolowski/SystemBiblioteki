﻿using Biblioteka.Models;
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
                Repository repo_book = repositories.ElementAtOrDefault(item.Repository.RepositoryID-1);

                if (repo_book.Amount != 0)
                {
                    Borrowing b = new Borrowing
                    {
                        ReaderID = userId,
                        Borrow_date = DateTime.Now,
                        BookID = item.BookID,
                        PenaltyID = 1,
                        QueueID = 0,
                        Returned= false

                    };
                    b.Return_date = b.Borrow_date.AddDays(1);
                    borrowingVM.Dodaj(b);
                    repositoryVM.Minus_amount(repo_book);
                   
                }
                else
                {
                    return RedirectToAction("Borrow_failed");//trzeba zablokować możliwość wypożyczenia gdy nie jest dostępna
                }
            }
            return View("Success_borrow");
        }
    }
}