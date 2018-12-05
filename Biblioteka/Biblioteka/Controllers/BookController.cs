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
            return View(b);
        }
        [HttpPost]
        public ActionResult Add(Book a)
        {
            BookVM vm = new BookVM();
            List<Book> list = vm.Get_list();

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
    }
}