using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretMvc.Models.Sınıflar;

namespace ETicaretMvc.Controllers
{
    public class AnasayfaController : Controller
    {
        Context c = new Context();
        // GET: Anasayfa
        [Authorize]
        public ActionResult Index(string p )


        {
            var ad = (string)Session["CariAd"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariAd == ad);
            ViewBag.m = ad;

            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
       
        [HttpGet]
        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Sepet p)
        {
            p.CariId = int.Parse(Session["id"].ToString());
            c.Sepets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = c.Uruns.Find(id);

            return View("UrunGetir", urun);
        }
        public ActionResult cari()
        {
            var ad = (string)Session["CariAd"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariAd == ad);
            ViewBag.m = ad;
            return View(degerler);
        }
       
    }
}