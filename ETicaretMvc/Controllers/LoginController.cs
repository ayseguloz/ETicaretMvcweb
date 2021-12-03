using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretMvc.Models.Sınıflar;
using System.Web.Security;

namespace ETicaretMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();

       

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
     [HttpGet]
        public ActionResult CariLogin1()
        {
            return View() ;
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariAd, false);
               Session["CariAd"] = bilgiler.CariAd.ToString();
                Session["id"] = bilgiler.CariId;
                return RedirectToAction("Index", "Anasayfa");

               
            }
            else
            {
                return RedirectToAction("Index","Login");
        }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi
            && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["CariMail"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
    }
}