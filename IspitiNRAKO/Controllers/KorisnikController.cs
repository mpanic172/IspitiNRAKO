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
    public class KorisnikController : Controller
    {
        KorisnikRepozitorij repo = new KorisnikRepozitorij();

        // GET: Korisnik
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        // GET: Korisnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = repo.FindById(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisnik/Create
        public ActionResult Create()
        {
            ViewBag.KompanijaId = repo.KompanijaList();
            ViewBag.SpolId = repo.SpolList();
            ViewBag.StrucnaSpremaId = repo.StrucnaSpremaList();
            return View();
        }

        // POST: Korisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKorisnik,Username,Password,Ime,Prezime,Email,Adresa,OIB,Telefon,Zanimanje,SpolId,StrucnaSpremaId,KompanijaId")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                repo.Add(korisnik);
                repo.Save();
                return RedirectToAction("Index");
            }


            ViewBag.KompanijaId = repo.KompanijaList(korisnik.KompanijaId);
            ViewBag.SpolId = repo.SpolList(korisnik.SpolId);
            ViewBag.StrucnaSpremaId = repo.StrucnaSpremaList(korisnik.StrucnaSpremaId);

            return View(korisnik);
        }

        // GET: Korisnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = repo.FindById(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }

            ViewBag.KompanijaId = repo.KompanijaList(korisnik.KompanijaId);
            ViewBag.SpolId = repo.SpolList(korisnik.SpolId);
            ViewBag.StrucnaSpremaId = repo.StrucnaSpremaList(korisnik.StrucnaSpremaId);

            return View(korisnik);
        }

        // POST: Korisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKorisnik,Username,Password,Ime,Prezime,Email,Adresa,OIB,Telefon,Zanimanje,SpolId,StrucnaSpremaId,KompanijaId")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                repo.Update(korisnik);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.KompanijaId = repo.KompanijaList(korisnik.KompanijaId);
            ViewBag.SpolId = repo.SpolList(korisnik.SpolId);
            ViewBag.StrucnaSpremaId = repo.StrucnaSpremaList(korisnik.StrucnaSpremaId);

            return View(korisnik);
        }

        // GET: Korisnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = repo.FindById(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = repo.FindById(id);
            repo.Delete(korisnik);
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
