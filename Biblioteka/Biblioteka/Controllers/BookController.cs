﻿using Biblioteka.DAL;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using File = Biblioteka.Models.File;

namespace Biblioteka.Controllers
{
    public class BookController : Controller
    {
        DB dB = new DB();

        public ActionResult Index(string searching, string searchby)
        {
            if (searching != null)
            {


                if (Session["login"] != null)
                {

                    var userId = (Int32)(Session["adminID"]);
                    var user_history = dB.Histories.Where(a => a.AccountID == userId).ToList();

                    if (user_history.Count() >= 5)
                    {
                        var oldest_search = user_history.OrderBy(a => a.SearchDate).First();
                        oldest_search.Search = searching;
                        oldest_search.SearchDate = DateTime.Now;
                        dB.Histories.AddOrUpdate(oldest_search);
                        dB.SaveChanges();
                    }
                    else
                    {
                        dB.Histories.Add(new History { AccountID = userId, Search = searching, SearchDate = DateTime.Now });
                        dB.SaveChanges();
                    }
                }

            }


            //var book_aut = dB.Books
            //   .Select(a => new 
            //   {
            //       Title = a.Title,
            //       ISBN = a.ISBN,
            //       Pages = a.Pages,
            //       Year = a.Year,
            //       Authors = a.AutBooks.Select(b => new  { Name = b.Author.Name, Surname = b.Author.Surname }).ToList()
            //   }).ToList();




            var book_aut = dB.Books
      .Select(a => new Autors_books
      {
          BookID = a.BookID,
          Title = a.Title,
          ISBN = a.ISBN,
          Pages = a.Pages,
          Year = a.Year,
          Authors = a.AutBooks.Select(b => new Autors_books.Autors_books2
          {
              Name = b.Author.Name,
              Surname = b.Author.Surname,
              Books = b.Author.AutBooks.Select(ab => new Autors_books
              {
                  BookID = ab.Book.BookID,
                  Title = ab.Book.Title,
                  ISBN = ab.Book.ISBN,
                  Pages = ab.Book.Pages,
                  Year = ab.Book.Year,
                  Authors = ab.Book.AutBooks.Select(b2 => new Autors_books.Autors_books2 { Name = b2.Author.Name, Surname = b2.Author.Surname }).ToList()
              }
          )
          })
          .ToList(),
      }).ToList();





            Int32.TryParse(searching, out int s);

            switch (searchby)
            {
                case "ISBN":
                    return View(dB.Books.Where(x => x.ISBN == s || searching == null).ToList());
                    break;
                case "Author":
                    return View(book_aut
                        .SelectMany(x => x.Authors 
                        .Where(a => a.Surname.StartsWith(searching))).ToList());
                    break;
                    
                case "Title":
                    return View(dB.Books.Where(x => x.Title.StartsWith(searching) || searching == null).ToList());
                    break;
                case "Year":
                    return View(dB.Books.Where(x => x.Year == s || searching == null).ToList());
                    break;
                default:
                    return View(book_aut);
            }



        }

        public JsonResult GetHistory(string searchTerm)
        {
            var userId = (Int32)(Session["adminID"]);
            var user_history = dB.Histories.Where(a => a.AccountID == userId).ToList();
            var books = dB.Books.ToList();
            if (searchTerm != null)
            {
                user_history = user_history.Where(a => a.Search.Contains(searchTerm)).ToList();
                books = books.Where(a => a.Title.Contains(searchTerm)).ToList();
            }
            var modifiedData = user_history.Select(a => new
            {
                search = a.Search,
            });
            var modifiedData2 = books.Select(a => new
            {
                id = a.BookID,
                search = a.Title

            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Bok()
        {
            BookVM vm = new BookVM();
            CategoryVM vm1 = new CategoryVM();
            AuthorVM vm2 = new AuthorVM();
            dynamic mymodel = new ExpandoObject();
            mymodel.book = vm.Get_list();
            mymodel.cate = vm1.Get_list();
            mymodel.auth = vm2.Get_list();
            return View(mymodel);
        }
        public ActionResult Add(int id = 0)
        {
            AuthorVM authorVM = new AuthorVM();
            ViewBag.Authors = authorVM.Get_list().Select(a => a.Name + " " + a.Surname);


            Book b = new Book();
            CategoryVM vm2 = new CategoryVM();
            ViewBag.kategorie = new SelectList(vm2.Get_list(), "CategoryID", "Name");
            return View(b);
        }
        [HttpPost]
        public ActionResult Add(Book a)
        {
            BookVM vm = new BookVM();
            List<Book> list = vm.Get_list();
            CategoryVM vm2 = new CategoryVM();
            ViewBag.kategorie = new SelectList(vm2.Get_list(), "CategoryID", "Name");
            // dodać plusowanie w repo
            vm.Dodaj(a);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(int id, HttpPostedFileBase file)
        {
            BookVM vm = new BookVM();
            Book u = vm.Find(id);
            if (file == null)
            {
                return View(u);
            }
            string path = Server.MapPath("~/App_Data/File");
            string fileName = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(path, fileName);
            file.SaveAs(fullPath);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            BookVM vm = new BookVM();
            List<Book> lista = vm.Get_list();
            Book a = lista.Where(s => s.BookID == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book m)
        {
            BookVM vm = new BookVM();
            vm.Update(m);
            ViewBag.Succesmessage = "Edycja pomyślna!";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            ViewBag.viewBag = dB.Books.Where(a => a.BookID == 4).SelectMany(a => a.AutBooks).Select(a => new { Name = a.Author.Name, Surname = a.Author.Surname }).ToList();
            BookVM vm = new BookVM();
            Book u = vm.Find(id);
            return View(u);
        }
      
       
        public ActionResult Delete(int id)
        {
            BookVM vm = new BookVM();
            // dodać usuwanie w repo
            vm.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult NewBooks()
        {
            BookVM vm = new BookVM();
            List<Book> list = vm.Get_list();
            //TODO w widoku foreach reverse i take(3)  -> @foreach (var u in Model.Reverse().Take(3))
            // pobranie z bazy ścieżek do okładek i zapisania w viewbagach i potem wypisanie ich w widoku w <img>
            return View();
        }
    }
}