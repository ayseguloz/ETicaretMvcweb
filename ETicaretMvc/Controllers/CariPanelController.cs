using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretMvc.Models.Sınıflar;

namespace ETicaretMvc.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        // GET: CariPanel
       
        public ActionResult Index()
        {
            var ad = (string)Session["CariAd"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariAd == ad);
            ViewBag.m = ad;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }
        
        }
}