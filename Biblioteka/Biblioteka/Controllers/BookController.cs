using Biblioteka.DAL;
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

        public ActionResult Index()
        {

            BookVM vm = new BookVM();
            CategoryVM cvm = new CategoryVM();
            ViewBag.Kats = new SelectList(cvm.Get_list(), "CategoryID", "Name");

            return View(dB.Books.ToList());


        }
        [HttpPost]
        public ActionResult Index(string searching, string searchby, int kats)
        {

            BookVM vm = new BookVM();
            List<Book> list = vm.Get_list().Where(a => a.CategoryID == kats).ToList();
            CategoryVM cvm = new CategoryVM();
            ViewBag.Kats = new SelectList(cvm.Get_list(), "CategoryID", "Name");

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




            //      var book_aut = dB.Books
            //.Select(a => new Autors_books
            //{
            //    BookID = a.BookID,
            //    Title = a.Title,
            //    ISBN = a.ISBN,
            //    Pages = a.Pages,
            //    Year = a.Year,
            //    Authors = a.AutBooks.Select(b => new Autors_books.Autors_books2
            //    {
            //        Name = b.Author.Name,
            //        Surname = b.Author.Surname,
            //        Books = b.Author.AutBooks.Select(ab => new Autors_books
            //        {
            //            BookID = ab.Book.BookID,
            //            Title = ab.Book.Title,
            //            ISBN = ab.Book.ISBN,
            //            Pages = ab.Book.Pages,
            //            Year = ab.Book.Year,
            //            Authors = ab.Book.AutBooks.Select(b2 => new Autors_books.Autors_books2 { Name = b2.Author.Name, Surname = b2.Author.Surname }).ToList()
            //        }
            //    )
            //    })
            //    .ToList(),
            //}).ToList();





            Int32.TryParse(searching, out int s);

            switch (searchby)
            {
                case "ISBN":
                    return View(dB.Books.Where(x => x.ISBN == s || searching == null).ToList());
                case "Title":
                    return View(dB.Books.Where(x => x.Title.StartsWith(searching) || searching == null).ToList());

                case "Year":
                    return View(dB.Books.Where(x => x.Year == s || searching == null).ToList());
                case "Category":
                    ViewBag.Kats = new SelectList(cvm.Get_list(), "CategoryID", "Name");
                    return View(list);
                default:
                    return View(dB.Books.Where(x => x.Title.StartsWith(searching) || searching == null).ToList());
            }



        }

        //public JsonResult GetHistory(string searchTerm)
        //{
        //    if ((Session["adminID"]) != null)
        //    {
        //        var userId = (Int32)(Session["adminID"]);
        //        var user_history = dB.Histories.Where(a => a.AccountID == userId).ToList();
        //        var books = dB.Books.ToList();
        //        if (searchTerm != null)
        //        {
        //            user_history = user_history.Where(a => a.Search.Contains(searchTerm)).ToList();
        //            books = books.Where(a => a.Title.Contains(searchTerm)).ToList();
        //        }
        //        var modifiedData = user_history.Select(a => new
        //        {
        //            search = a.Search,
        //        });
        //        var modifiedData2 = books.Select(a => new
        //        {
        //            id = a.BookID,
        //            search = a.Title

        //        });
        //        return Json(modifiedData, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult SearchHistory()
        {
            var userId = (Int32)(Session["adminID"]);
            var user_history = dB.Histories.Where(a => a.AccountID == userId).ToList();
            return View(user_history);
        }

        public ActionResult Add()
        {

            Book a = new Book();

            CategoryVM vm2 = new CategoryVM();

            ViewBag.kategorie = new SelectList(vm2.Get_list(), "CategoryID", "Name");
            return View(a);
        }


        [HttpPost]
        public ActionResult Add(Book a,int amount, HttpPostedFileBase file1, HttpPostedFileBase file2, String tag, String author)
        {
            CategoryVM vm2 = new CategoryVM();
            ViewBag.kategorie = new SelectList(vm2.Get_list(), "CategoryID", "Name");

            List<String> authors = new List<string>();
            authors.AddRange(author.Split(','));

            List<String> tags = new List<string>();
            tags.AddRange(tag.Split(','));
            
            using (var dbContextTransaction = dB.Database.BeginTransaction())
            {

                dB.Books.Add(a);

                
                dB.Repositories.Add(new Repository { ISBN=a.ISBN,RepositoryID=a.BookID,Book=a,Amount = amount });

                if (author != "")
                {
                    foreach (var item in authors)
                    {
                        var autorList = dB.Authors.Where(x => x.FullName.StartsWith(item)).ToList();
                        if (autorList.Count() != 0)
                        {
                            dB.AutBooks.AddOrUpdate(new AutBook { AuthorID = dB.Authors.Where(x => x.FullName == item).Select(x => x.AuthorID).FirstOrDefault(), Author = dB.Authors.Where(x => x.FullName == item).First(), BookID = a.BookID, Book = a });
                            dB.SaveChanges();
                        }
                        else
                        {
                            var name_surname = item.Split(' ');
                            
                            dB.Authors.Add(new Author { FullName = item, Name = name_surname[0], Surname = name_surname[1] });
                            dB.SaveChanges();
                            dB.AutBooks.Add(new AutBook { AuthorID = dB.Authors.Where(x => x.FullName == item).Select(x => x.AuthorID).FirstOrDefault(), Author = dB.Authors.Where(x => x.FullName == item).First(), BookID = a.BookID, Book = a });
                        }
                    }
                }
                if (tag != "")
                {
                    foreach (var item in tags)
                    {
                        var ta = dB.Tags.Where(x => x.Name == item).ToList();
                        if (ta.Count() != 0)
                        {
                            dB.TagBooks.AddOrUpdate(new TagBook { TagID = dB.Tags.Where(x => x.Name == item).Select(x => x.TagID).FirstOrDefault(), Tag = dB.Tags.Where(x => x.Name == item).First(), BookID = a.BookID });
                            dB.SaveChanges();
                        }
                        else
                        {
                            dB.Tags.Add(new Tag { Name = item });
                            dB.SaveChanges();
                            dB.TagBooks.Add(new TagBook { BookID = a.BookID, TagID = dB.Tags.Where(x => x.Name == item).Select(x => x.TagID).FirstOrDefault(), Tag = dB.Tags.Where(x => x.Name == item).First() });
                        }
                    }
                }
                //upload pliku
                if (file1 != null)
                {
                    //upload pliku
                    var model = Server.MapPath("~/App_Data/File/") + file1.FileName;
                    if (file1.ContentLength > 0)
                    {
                        file1.SaveAs(model);
                        dB.Files.Add(new File { Book = a, BookID = a.BookID, Name = "png", Path = model });
                        dB.SaveChanges();
                    }
                }
                if (file2 != null)
                {
                    //upload pliku
                    var model2 = Server.MapPath("~/App_Data/File/") + file2.FileName;
                    if (file2.ContentLength > 0)
                    {
                        file2.SaveAs(model2);
                        dB.Files.Add(new File { Book = a, BookID = a.BookID, Name = "pdf", Path = model2 });
                        dB.SaveChanges();
                    }
                }
                dB.SaveChanges();
                dbContextTransaction.Commit();

            }



            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {

            var a = dB.Books.Where(s => s.BookID == id).FirstOrDefault();

            CategoryVM vm2 = new CategoryVM();
            ViewBag.kategorie = new SelectList(vm2.Get_list(), "CategoryID", "Name");

            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book a, HttpPostedFileBase file1, HttpPostedFileBase file2, String tag)
        {
            CategoryVM vm2 = new CategoryVM();
            ViewBag.kategorie = new SelectList(vm2.Get_list(), "CategoryID", "Name");

            List<String> tags = new List<string>();
            tags.AddRange(tag.Split(','));


            using (var dbContextTransaction = dB.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in tags)
                    {
                        var ta = dB.Tags.Where(x => x.Name == item).ToList();
                        if (ta.Count() != 0)
                        {
                            if (dB.TagBooks.Where(x => x.BookID == a.BookID && x.TagID == dB.Tags.Where(y => y.Name == item).Select(y => y.TagID).FirstOrDefault()).ToList().Count() == 0)
                            {
                                dB.TagBooks.AddOrUpdate(new TagBook { TagID = dB.Tags.Where(x => x.Name == item).Select(x => x.TagID).FirstOrDefault(), Tag = dB.Tags.Where(x => x.Name == item).First(), BookID = a.BookID });
                                dB.SaveChanges();
                            }
                        }
                        else
                        {
                            dB.Tags.Add(new Tag { Name = item });
                            dB.SaveChanges();
                            dB.TagBooks.Add(new TagBook { BookID = a.BookID, TagID = dB.Tags.Where(x => x.Name == item).Select(x => x.TagID).FirstOrDefault(), Tag = dB.Tags.Where(x => x.Name == item).First() });
                        }
                    }

                    //upload pliku
                    if (file1 != null)
                    {
                        //upload pliku
                        var model = Server.MapPath("~/App_Data/File/") + file1.FileName;
                        if (file1.ContentLength > 0)
                        {
                            file1.SaveAs(model);
                            dB.Files.AddOrUpdate(new File { Book = a, BookID = a.BookID, Name = "png", Path = model });
                            dB.SaveChanges();
                        }
                    }
                    if (file2 != null)
                    {
                        //upload pliku
                        var model2 = Server.MapPath("~/App_Data/File/") + file2.FileName;
                        if (file2.ContentLength > 0)
                        {
                            file2.SaveAs(model2);
                            dB.Files.AddOrUpdate(new File { Book = a, BookID = a.BookID, Name = "pdf", Path = model2 });
                            dB.SaveChanges();
                        }
                    }

                    dB.Books.AddOrUpdate(a);
                    dB.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var idCat = dB.Books.Where(x => x.BookID == id).Select(x => x.CategoryID).FirstOrDefault().ToString();
            Int32.TryParse(idCat, out int id_cat);

            //Lista autorów
            ViewBag.Author = dB.Books.Where(a => a.BookID == id).SelectMany(a => a.AutBooks).Select(a => new { Name = a.Author.Name, Surname = a.Author.Surname }).ToList();

            ViewBag.Tags = dB.Books.Where(a => a.BookID == id).SelectMany(a => a.TagBooks).Select(a => a.Tag).ToList();

            ViewBag.Category = dB.Categories.Where(x => x.CategoryID == id_cat).Select(x => x.Name).FirstOrDefault().ToString();
            BookVM vm = new BookVM();
            Book u = vm.Find(id);
            return View(u);
        }
        public ActionResult TagSearch(String tag)
        {
            var Bookstags = dB.TagBooks.Where(x => x.Tag.Name == tag).Select(x => x.Book).ToList();
            return View(Bookstags);
        }
        public FileResult Download(int id)
        {

            var filePath = dB.Files.Where(x => x.Book.BookID == id && x.Name == "png").Select(x => x.Path).FirstOrDefault();

            //if (filePath != null) { return File(filePath, "image/png"); } else
            //{
            //    return View("~/Views//Book/Empty.cshtml");
            //}
            return File(filePath, "image/png");
        }

        public FileResult Download2(int id)
        {
            var filePath = dB.Files.Where(x => x.Book.BookID == id && x.Name == "pdf").Select(x => x.Path).FirstOrDefault();
           
            return File(filePath, "application/pdf");
        }

        public ActionResult Delete(int id)
        {
            var book = dB.Books.Where(x => x.BookID == id).FirstOrDefault();
            var repo = dB.Repositories.Where(x => x.RepositoryID == id).FirstOrDefault();
            dB.Books.Remove(book);
            if (repo != null)
            {
                dB.Repositories.Remove(repo);
            }
            dB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NewBooks()
        {
            BookVM vm = new BookVM();
            List<Book> list = vm.Get_list();
            var list_books = list.OrderByDescending(a => a.BookID);
            var listTop3 = list_books.Take(3);
            List<int> list_categoryID = new List<int>();
            List<String> list_categoryName = new List<string>();

            foreach (var item in listTop3)
            {
                Int32.TryParse(dB.Books.Where(x => x.BookID == item.BookID).Select(x => x.CategoryID).FirstOrDefault().ToString(), out int id_cat);
                list_categoryID.Add(id_cat);
            }
            foreach (var item in list_categoryID)
            {
                list_categoryName.Add(dB.Categories.Where(x => x.CategoryID == item).Select(x => x.Name).FirstOrDefault().ToString());
            }
            ViewBag.Category = list_categoryName;
            //TODO w widoku foreach reverse i take(3)  -> @foreach (var u in Model.Reverse().Take(3))
            // pobranie z bazy ścieżek do okładek i zapisania w viewbagach i potem wypisanie ich w widoku w <img>
            return View(listTop3);
        }
    }
}