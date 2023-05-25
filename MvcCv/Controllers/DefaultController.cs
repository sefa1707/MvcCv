using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MvcCvDbEntities db=new MvcCvDbEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitim.ToList();
            return PartialView(egitimler);
        }

        public ActionResult Yetenek()
        {
            var yetenek = db.TblYetenek.ToList();
            return PartialView(yetenek);
        }

        public ActionResult Hobi()
        {
            var hobi = db.TblHobi.ToList();
            return PartialView(hobi);
        }

        public ActionResult Sertifika()
        {
            var sertifika = db.TblSertifika.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public ActionResult iletisim()
        {
            var iletisim = db.Tbliletisim.ToList();
            return PartialView(iletisim);
        }
        [HttpPost]
        public ActionResult iletisim(Tbliletisim m)
        {
            m.Tarih = DateTime.Parse( DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(m);
            db.SaveChanges();
            return PartialView();
        }
    }
}