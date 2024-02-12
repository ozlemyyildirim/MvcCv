using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
 
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbl_Iletisim> repo = new GenericRepository<Tbl_Iletisim>();
        public ActionResult Index()
        {
            var mesaj = repo.List();
            return View(mesaj);
        }
    }
}