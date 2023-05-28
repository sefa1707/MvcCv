using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifika> repo = new GenericRepository<TblSertifika>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
 
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.sertifika = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifika t)
        {
            var s = repo.Find(x => x.ID == t.ID);
            s.Aciklama = t.Aciklama;
            s.Tarih = t.Tarih;
            repo.TUpdate(s);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifika p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var s = repo.Find(x => x.ID == id);
            repo.TDelete(s);
            return RedirectToAction("Index");
        }
    }
}