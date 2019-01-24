using Biblioteka.CustomFilters;
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
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            NewsVM vm = new NewsVM();
            List<News> list_news = vm.Get_list().ToList();
            ViewBag.News = list_news;
            return View(list_news);
        }
        [AdminRole]
        public ActionResult Add(int id = 0)
        {
            News b = new News();
            NewsVM vm2 = new NewsVM();
            b.Date = DateTime.Now;
            return View(b);
        }
        [HttpPost]
        public ActionResult Add(News a)
        {
            //NewsVM vm = new NewsVM();
            //List<News> list = vm.Get_list();
            //NewsVM vm2 = new NewsVM();

            //vm.Dodaj(a);
            DB dB = new DB();
            a.Date = DateTime.Now;
            dB.News.Add(a);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            NewsVM vm = new NewsVM();
            List<News> lista = vm.Get_list();
            News a = lista.Where(s => s.NewsID == id).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News m)
        {
            NewsVM vm = new NewsVM();
            vm.Update(m);
            ViewBag.Succesmessage = "Edycja pomyślna!";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            NewsVM vm = new NewsVM();
            News u = vm.Find(id);
            return View(u);
        }
        public ActionResult Delete(int id)
        {
            NewsVM vm = new NewsVM();
            // dodać usuwanie w repo
            vm.Delete(id);
            return RedirectToAction("Index");
        }
    }
}