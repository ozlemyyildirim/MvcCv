using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{

    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Tbl_Sertifikalarim> repo = new GenericRepository<Tbl_Sertifikalarim>();


        public ActionResult Index()
        {
            var sertifika = repo.List();

            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(Tbl_Sertifikalarim t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Aciklama = t.Aciklama;
            sertifika.Tarih = t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(Tbl_Sertifikalarim p, HttpPostedFileBase dosya)
        {
            if (dosya != null && dosya.ContentLength > 0)
            {
                try
                {
                    string dosyaAdi = Path.GetFileName(dosya.FileName);
                    string dosyaYolu = Path.Combine(Server.MapPath("~/Dosyalar"), dosyaAdi);
                    dosya.SaveAs(dosyaYolu);

                    p.Link = Url.Content("~/Dosyalar/" + dosyaAdi); // Dosya yolunu modele ekleyin

                    // Tbl_Sertifikalarim modelini veritabanına kaydedin
                    repo.TAdd(p);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Dosya yüklenirken bir hata oluştu: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "Dosya seçmediniz veya dosya boş.";
            }

            // Eğer bir hata oluştuysa veya dosya seçilmediyse, tekrar YeniSertifika sayfasını gösterin
            return View();
        }
  
  

    private string FilePathResult(string fileName)
    {
        throw new NotImplementedException();
    }

    public ActionResult SertifikaSil(int id)
    {
        var sertifika = repo.Find(x => x.ID == id);

        repo.TDelete(sertifika);

        return RedirectToAction("Index");
    }
}
}