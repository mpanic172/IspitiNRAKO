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
    public class OdgovorController : Controller
    {
        OdgovorRepozitorij repo = new OdgovorRepozitorij();
        PitanjeRepozitorij pitanjeRepo = new PitanjeRepozitorij();

        // GET: Odgovor
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }



        // GET: Odgovor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovor odgovor = repo.FindById(id);
            if (odgovor == null)
            {
                return HttpNotFound();
            }
            return View(odgovor);
        }

        public ActionResult Prikaz(int? idPitanje)
        {
            if (idPitanje == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pitanje pitanje = pitanjeRepo.FindById(idPitanje);
            if (pitanje == null)
            {
                return HttpNotFound();
            }


            return View(pitanje.Odgovors);
        }


        // GET: Odgovor/Create
        public ActionResult Create()
        {
            ViewBag.PitanjeId = repo.PitanjaList();
            return View();
        }

        // POST: Odgovor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOdgovor,Tekst,Tocno,PitanjeId")] Odgovor odgovor)
        {
            if (ModelState.IsValid)
            {
                repo.Add(odgovor);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.PitanjeId = repo.PitanjaList(odgovor.PitanjeId);
            return View(odgovor);
        }

        // GET: Odgovor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovor odgovor = repo.FindById(id);
            if (odgovor == null)
            {
                return HttpNotFound();
            }
            ViewBag.PitanjeId = repo.PitanjaList(odgovor.PitanjeId);
            return View(odgovor);
        }

        // POST: Odgovor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOdgovor,Tekst,Tocno,PitanjeId")] Odgovor odgovor)
        {
            if (ModelState.IsValid)
            {
                repo.Update(odgovor);
                repo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PitanjeId = repo.PitanjaList(odgovor.PitanjeId);
            return View(odgovor);
        }

        // GET: Odgovor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovor odgovor = repo.FindById(id);
            if (odgovor == null)
            {
                return HttpNotFound();
            }
            return View(odgovor);
        }

        // POST: Odgovor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Odgovor odgovor = repo.FindById(id);
            repo.Delete(odgovor);
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
