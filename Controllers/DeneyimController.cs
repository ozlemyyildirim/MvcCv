using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
   
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        
        public ActionResult Index()
        {
            var deneyim = repo.List();
            return View(deneyim);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim p)
        {

            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {

            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
                 
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimlerim p)
        {
            Tbl_Deneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Aciklama = p.Aciklama;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}