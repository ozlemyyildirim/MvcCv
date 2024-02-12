using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
   
    public class EgitimController : Controller
    {
        // GET: Yetenek
        GenericRepository<Tbl_Egitimlerim> repo = new GenericRepository<Tbl_Egitimlerim>();
       
        public ActionResult Index()
        {
            var egitimler = repo.List();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            Tbl_Egitimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGuncelle(Tbl_Egitimlerim p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}