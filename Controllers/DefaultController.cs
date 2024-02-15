using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;


namespace MvcCv.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.Tbl_SosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalMedya);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.Tbl_Egitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.Tbl_Yeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobi()
        {
            var hobiler = db.Tbl_Hobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.Tbl_Sertifikalarim.ToList();
            return PartialView(sertifikalar);
        }

        public PartialViewResult Proje()
        {
            var projeler = db.Tbl_Projelerim.ToList();
            return PartialView(projeler);
        }
        public PartialViewResult Admin()
        {
            var kullanici = db.Tbl_Admin.ToList();
            return PartialView(kullanici);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Tbl_Iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}