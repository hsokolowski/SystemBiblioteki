using Biblioteka.CustomFilters;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    [WorkerRole]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryVM vm = new CategoryVM();
            List<Category> list = vm.Get_list();
            return View(list);
        }
        //dodać do nadrzędnego ojca z kategorii
        
        public ActionResult Add(int id = 0)
        {
            Category c = new Category();
            return View(c);
        }
        [HttpPost]
        public ActionResult Add(Category c)
        {
            CategoryVM vm = new CategoryVM();
            List<Category> list = vm.Get_list();

            if (list.Any(x => x.Name == c.Name))
            {
                ViewBag.DuplicateMessage = "Taka nazwa już istnieje!";
                return View("Add", c);
            }
            vm.Dodaj(c);
            return RedirectToAction("Index");
        }
        public ActionResult Kategorie()
        {
            CategoryVM cvm = new CategoryVM();
            List<Category> lista2 = cvm.Get_list();
            return View(lista2);
        }
        //ToDO edit 
    }
}