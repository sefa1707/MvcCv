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
            var deneyimler = repo.List();
            return View(deneyimler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyim d)
        {
            repo.TAdd(d);
            return RedirectToAction("Index");

        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyim d)
        {
            TblDeneyim t = repo.Find(x => x.ID == d.ID);
            t.Baslik = d.Baslik;
            t.AltBaslik = d.AltBaslik;
            t.Tarih = d.Tarih;
            t.Aciklama = d.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}