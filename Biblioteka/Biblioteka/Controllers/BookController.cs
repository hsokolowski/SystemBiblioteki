using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            //TODO zmienić na listę z poleceniem SQL aby wypiwywana była nazwa kate i autor cały

            BookVM vm = new BookVM();
            List<Book> list = vm.Get_list();
            CategoryVM cvm = new CategoryVM();
            ViewBag.Kats = new SelectList(cvm.Get_list(), "CategoryID", "Name");

            return View(list);
        }
        [HttpPost]
        public ActionResult Index( int Kats)
        {
            
            BookVM vm = new BookVM();
            List<Book> list =vm.Get_list().Where(a=>a.CategoryID==Kats).ToList();
            CategoryVM cvm=new CategoryVM();
            ViewBag.Kats = new SelectList(cvm.Get_list(), "CategoryID", "Name");
            return View(list);
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
            ViewBag.kategorie = new SelectList(vm2.Get_list(), "ID", "Name");
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
            CategoryVM vm2 = new CategoryVM();
            List<Category> list2 = vm2.Get_list();

            var final = (from p in list
                                   join c in list2 on p.CategoryID equals c.CategoryID
                                     select new { ID = p.BookID, Tytul = p.Title, Rok = p.Year, Kategoria = c.Name, Strony = p.Pages, ISBN = p.ISBN, DlaKogo = p.for_who_string });
            ViewBag.Final = final;
            //TODO w widoku foreach reverse i take(3)  -> @foreach (var u in Model.Reverse().Take(3))
            // pobranie z bazy ścieżek do okładek i zapisania w viewbagach i potem wypisanie ich w widoku w <img>
            return View(list); 
        }
    }
}