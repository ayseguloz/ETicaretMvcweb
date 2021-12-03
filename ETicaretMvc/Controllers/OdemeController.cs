using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretMvc.Models.Sınıflar;

namespace ETicaretMvc.Controllers
{
    public class OdemeController : Controller
    {
        // GET: Odeme

        Context c = new Context();
        [Authorize]
        public ActionResult Index(string p)
        {

            var ad = (string)Session["CariAd"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariAd == ad);
            ViewBag.m = ad;

            int id = int.Parse(Session["id"].ToString());
            var urunler = from x in c.Sepets
                          where x.CariId == id
                          select x  ;
                          
          
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.Urun.UrunAd.Contains(p));
            }
            return View(urunler.ToList());

           

        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Sepets.Find(id);
            c.Sepets.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
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