using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{

    public class ProjeController : Controller
    {
        // GET: Yetenek
        GenericRepository<Tbl_Projelerim> repo = new GenericRepository<Tbl_Projelerim>();

        public ActionResult Index()
        {
            var Projeler = repo.List();
            return View(Projeler);
        }
        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjeEkle(Tbl_Projelerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ProjeSil(int id)
        {
            var Proje = repo.Find(x => x.ID == id);
            repo.TDelete(Proje);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjeGuncelle(int id)
        {
            Tbl_Projelerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult ProjeGuncelle(Tbl_Projelerim p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.ProjeAdi = p.ProjeAdi;
            t.ProjeDetayi = p.ProjeDetayi;
            t.KullanilanTeknoloji = p.KullanilanTeknoloji;
            t.ProejeLink = p.ProejeLink;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}