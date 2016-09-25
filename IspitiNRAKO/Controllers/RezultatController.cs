using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IspitiNRAKO;
using IspitiNRAKO.Repozitorij;

namespace IspitiNRAKO.Controllers
{
    public class RezultatController : Controller
    {
        RezultatRepozitorij repo = new RezultatRepozitorij();

        // GET: Rezultat
        public ActionResult Index()
        {

            int id = Int32.Parse(Session["UserID"].ToString());

            return View(repo.GetRezultati(id));
        }


        /*
        // GET: Rezultat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezultat rezultat = db.Rezultats.Find(id);
            if (rezultat == null)
            {
                return HttpNotFound();
            }
            return View(rezultat);
        }
        */

        /*
        // GET: Rezultat/Create
        public ActionResult Create()
        {
            ViewBag.IspitId = new SelectList(db.Ispits, "IdIspit", "Naziv");
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "IdKorisnik", "Username");
            return View();
        }
        */


        /*
        // POST: Rezultat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRezultat,Vrijeme,Prolaz,BrojBodova,Postotak,KorisnikId,IspitId")] Rezultat rezultat)
        {
            if (ModelState.IsValid)
            {
                db.Rezultats.Add(rezultat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IspitId = new SelectList(db.Ispits, "IdIspit", "Naziv", rezultat.IspitId);
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "IdKorisnik", "Username", rezultat.KorisnikId);
            return View(rezultat);
        }
        */
        
        /*
        // GET: Rezultat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezultat rezultat = db.Rezultats.Find(id);
            if (rezultat == null)
            {
                return HttpNotFound();
            }
            ViewBag.IspitId = new SelectList(db.Ispits, "IdIspit", "Naziv", rezultat.IspitId);
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "IdKorisnik", "Username", rezultat.KorisnikId);
            return View(rezultat);
        }
        */

        /*
        // POST: Rezultat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRezultat,Vrijeme,Prolaz,BrojBodova,Postotak,KorisnikId,IspitId")] Rezultat rezultat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezultat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IspitId = new SelectList(db.Ispits, "IdIspit", "Naziv", rezultat.IspitId);
            ViewBag.KorisnikId = new SelectList(db.Korisniks, "IdKorisnik", "Username", rezultat.KorisnikId);
            return View(rezultat);
        }
        */

        /*
        // GET: Rezultat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezultat rezultat = db.Rezultats.Find(id);
            if (rezultat == null)
            {
                return HttpNotFound();
            }
            return View(rezultat);
        }
        */

            /*
        // POST: Rezultat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezultat rezultat = db.Rezultats.Find(id);
            db.Rezultats.Remove(rezultat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    */
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
