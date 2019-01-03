using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            AuthorVM vm = new AuthorVM();
            List<Author> list = vm.Get_list();
            return View(list);
        }
        // zmienić view model - dodawanie przez druga tabele autbook
        public ActionResult Add(int id = 0)
        {
            Author a = new Author();
            return View(a);
        }
        [HttpPost]
        public ActionResult Add(Author a)
        {
            AuthorVM vm = new AuthorVM();
            List<Author> list = vm.Get_list();

            if (list.Any(x => x.Name == a.Name && x.Surname == a.Surname))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("Autor", a);
            }
            vm.Dodaj(a);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            AuthorVM vm = new AuthorVM();
            List<Author> lista = vm.Get_list();
            Author a = lista.Where(s => s.AuthorID == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author m)
        {
            AuthorVM vm = new AuthorVM();
            vm.Update(m);
            ViewBag.Succesmessage = "Edycja pomyślna!";
            return RedirectToAction("Index"); //zmienić
        }
        public ActionResult Details(int id)
        {
            AuthorVM vm = new AuthorVM();
            Author u = vm.Find(id);
            return View(u);
        }
        public ActionResult Delete(int id)
        {
            AuthorVM vm = new AuthorVM();
            vm.Delete(id);
            return RedirectToAction("Index");//zmienić
        }
    }
}