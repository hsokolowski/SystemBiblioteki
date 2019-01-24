using Biblioteka.CustomFilters;
using Biblioteka.DAL;
using Biblioteka.Models;
using Biblioteka.ModelView;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
//using static Biblioteka.Models.CustomAuthorizeAttribute;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            NewsVM vm = new NewsVM();
            List<News> list_news = vm.Get_list().ToList();
            list_news.Reverse();
            ViewBag.News = list_news.Take(3);
            //-----
            AccountVM userBL = new AccountVM();
            List<Account> list = userBL.Get_list();
            return View(list);
        }
        
        public ActionResult Koszyk()
        {
            var list = System.Web.HttpContext.Current.Session["Zamowienie"];
            return View(list);
        }
        [Authorize]
        public ActionResult Koszyk2(int id, int kto)
        {
            BookVM gm = new BookVM();
            List<Book> list = gm.Get_list();

            //BorrowingVM vm = new BorrowingVM();
            //Borrowing b = new Borrowing();
            
            int licznik=0;
            var tym = list.SingleOrDefault(m => m.BookID == id);

            List<Book> koszyk;
            if (Session["Zamowienie"] != null)
            {
                koszyk = (List<Book>)Session["Zamowienie"];
                licznik = koszyk.Count();
            }
            else  koszyk = new List<Book>();



            DB db = new DB();
            var limit = db.Longlifes.Where(x => x.LonglifeID == 1).FirstOrDefault().limit;

            if (tym != null)
            {
                if (licznik >= limit)
                {
                    TempData["limit"] = "Maxymalnie można wypożyczyć 5 książek!";
                    return RedirectToAction("Index", "Book");
                }
                koszyk.Add(tym);
                licznik = koszyk.Count();
                HttpContext.Session["Zamowienie"] = koszyk;
                Session["Licznik"] = licznik;
                //

                return View("Koszyk", koszyk);
            }
            else
            {
                TempData["Message"] = "Ten film jest już w Ulubionych!";
                TempData["ID_z_ulub"] = id;
                return RedirectToAction("Index","Book");
                //jest w bazie
            }
        }
        public ActionResult DeleteKoszyk(int id)
        {
            List<Book> list =(List<Book>) System.Web.HttpContext.Current.Session["Zamowienie"];
            Book book =list.Where(m=>m.BookID==id).FirstOrDefault();
            list.Remove(book);
            var tmp = Session["Licznik"].ToString();
            Session["Licznik"] =Int32.Parse(tmp)-1;
            Session["Zamowienie"] = list;
            return View("Koszyk", list);
        }
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account user, string ReturnUrl)  //Autoryzacja Logownie
        {
            var url = ViewBag.ReturnUrl;
            AuthorizationVM avm = new AuthorizationVM();
            using (DAL.DB db = new DAL.DB())
            {
                //var tym = Encrypt.GetHash(user.password);
                var userdeatils = db.Accounts.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefault();
                if (userdeatils == null)
                {
                    ViewBag.LoginErrorMessage = "Niepoprawny login lub hasło";
                    return View("Login", user);
                }
                else
                {
                    if(userdeatils.Active==false)
                    {
                        ViewBag.LoginErrorMessage = "Konto nie aktywowane";
                        return View("Login", user);
                    }
                    
                    ///
                    int licznik;
                    List<Book> tmp = (List<Book>)Session["Zamowienie"];
                    if (tmp != null)
                    {
                        licznik = tmp.Count();
                    }
                    else licznik =0;
                    
                    Session["Licznik"] = licznik;
                    ///
                    Session["adminID"] = userdeatils.AccountID;

                    Session["login"] = userdeatils.Login;

                    if (userdeatils.Role == Role.Admin)
                    {
                        Session["IsAdmin"] = 1; // jest adminem
                    }
                    else if (userdeatils.Role == Role.Worker)
                    {
                        Session["IsAdmin"] = 2; // jest pracownikiem
                    }
                    else
                    {
                        Session["IsAdmin"] = 3; // jest czytaczem
                    }

                    FormsAuthentication.SetAuthCookie(user.Login, false);
                    
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        public ActionResult Logout()
        {
            int userid = (int)Session["adminID"];
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
       
 
        

        

       

    }
}