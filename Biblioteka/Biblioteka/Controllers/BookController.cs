using Biblioteka.DAL;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class BookController : Controller
    {
        DB dB = new DB();
       
        public ActionResult Index(string searching,string option)
        {
            if (searching!=null)
            {
                if (Session["login"] != null)
                {
                    int counter = 0;
                    var history = dB.Histories.ToList();
                    var NewSearch = new History();


                    var userId = (Int32)(Session["adminID"]);
                    foreach (var item in history)
                    {
                        if (item.AccountID == userId)
                        {
                            counter++;
                        }
                    }

                    if (counter < 5)
                    {
                        NewSearch.AccountID = userId;
                        NewSearch.Search = searching;
                        NewSearch.SearchDate = DateTime.Now;
                        dB.Histories.Add(NewSearch);
                        dB.SaveChanges();

                    }
                    else
                    {
                        var userSearch = dB.Histories.Where(m => m.AccountID.Equals(userId)).ToList();


                        System.DateTime today = System.DateTime.Now;
                        System.TimeSpan duration = userSearch.Select(m => m.SearchDate - DateTime.Now).Min();
                        System.DateTime answer = today.Add(duration);
                       
                        var oldest = userSearch.Where(m => m.SearchDate == answer).Max();

                        oldest.Search = searching;
                        oldest.SearchDate = DateTime.Now;
                        dB.Histories.AddOrUpdate(oldest);
                        dB.SaveChanges();

                    }
                }

            }
            

            switch (option)
            {
                case "ISBN":
                    
                    break;
                case "":
                    Console.WriteLine("Case 2");
                    break;
                default:
                    break;
            }

            return View(dB.Books.Where(x=>x.Title.StartsWith(searching) || searching == null).ToList());
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
            ViewBag.Authors = authorVM.Get_list().Select(a => a.Name+ " " + a.Surname);
             

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