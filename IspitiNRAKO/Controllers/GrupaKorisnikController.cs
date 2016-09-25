using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IspitiNRAKO;
using IspitiNRAKO.CustomAttributes;
using IspitiNRAKO.Repozitorij;

namespace IspitiNRAKO.Controllers
{
    [LoginAdmins]
    public class GrupaKorisnikController : Controller
    {
        GrupaKorisnikRepozitorij repo = new GrupaKorisnikRepozitorij();

        // GET: GrupaKorisnik
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        // GET: GrupaKorisnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupaKorisnik grupaKorisnik = repo.FindById(id);
            if (grupaKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(grupaKorisnik);
        }

        // GET: GrupaKorisnik/Create
        public ActionResult Create()
        {
            ViewBag.GrupaId = repo.GrupaList();
            ViewBag.KorisnikId = repo.KorisnikList();
            return View();
        }

        // POST: GrupaKorisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupaKorisnik,KorisnikId,GrupaId")] GrupaKorisnik grupaKorisnik)
        {
            if (ModelState.IsValid)
            {
                repo.Add(grupaKorisnik);
                repo.Save();
                return RedirectToAction("Index");
            }


            ViewBag.GrupaId = repo.GrupaList(grupaKorisnik.GrupaId);
            ViewBag.KorisnikId = repo.KorisnikList(grupaKorisnik.KorisnikId);

            return View(grupaKorisnik);
        }

        // GET: GrupaKorisnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupaKorisnik grupaKorisnik = repo.FindById(id);
            if (grupaKorisnik == null)
            {
                return HttpNotFound();
            }

            ViewBag.GrupaId = repo.GrupaList(grupaKorisnik.GrupaId);
            ViewBag.KorisnikId = repo.KorisnikList(grupaKorisnik.KorisnikId);

            return View(grupaKorisnik);
        }

        // POST: GrupaKorisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupaKorisnik,KorisnikId,GrupaId")] GrupaKorisnik grupaKorisnik)
        {
            if (ModelState.IsValid)
            {
                repo.Update(grupaKorisnik);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GrupaId = repo.GrupaList(grupaKorisnik.GrupaId);
            ViewBag.KorisnikId = repo.KorisnikList(grupaKorisnik.KorisnikId);

            return View(grupaKorisnik);
        }

        // GET: GrupaKorisnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupaKorisnik grupaKorisnik = repo.FindById(id);
            if (grupaKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(grupaKorisnik);
        }

        // POST: GrupaKorisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupaKorisnik grupaKorisnik = repo.FindById(id);
            repo.Delete(grupaKorisnik);
            repo.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
