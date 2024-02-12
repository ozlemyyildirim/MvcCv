using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
  
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<Tbl_Yeteneklerim> repo = new GenericRepository<Tbl_Yeteneklerim>();
      
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult YetenekEkle(Tbl_Yeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id )
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            Tbl_Yeteneklerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekGuncelle(Tbl_Yeteneklerim p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
          
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}