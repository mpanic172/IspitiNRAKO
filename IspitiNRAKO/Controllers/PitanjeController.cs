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
    public class PitanjeController : Controller
    {
        PitanjeRepozitorij repo = new PitanjeRepozitorij();

        // GET: Pitanje
        public ActionResult Index()
        {

            return View(repo.GetAll);
        }

        // GET: Pitanje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = repo.FindById(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }
            return View(pitanje);
        }

        public ActionResult Odgovor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = repo.FindById(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Prikaz", "Odgovor", new { idPitanje = id });
        }

        // GET: Pitanje/Create
        public ActionResult Create()
        {

            ViewBag.SkupPitanjaId = repo.SkupPitanjaList();
            ViewBag.VrstaPitanjaId = repo.VrstaPitanjaList();
            return View();
        }

        // POST: Pitanje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPitanje,Tekst,Tezina,Aktivno,VrstaPitanjaId,SkupPitanjaId")] Pitanje pitanje)
        {
            if (ModelState.IsValid)
            {
                repo.Add(pitanje);
                repo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SkupPitanjaId = repo.SkupPitanjaList(pitanje.SkupPitanjaId);
            ViewBag.VrstaPitanjaId = repo.VrstaPitanjaList(pitanje.VrstaPitanjaId);
            return View(pitanje);
        }

        // GET: Pitanje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = repo.FindById(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkupPitanjaId = repo.SkupPitanjaList(pitanje.SkupPitanjaId);
            ViewBag.VrstaPitanjaId = repo.VrstaPitanjaList(pitanje.VrstaPitanjaId);
            return View(pitanje);
        }

        // POST: Pitanje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPitanje,Tekst,Tezina,Aktivno,VrstaPitanjaId,SkupPitanjaId")] Pitanje pitanje)
        {
            if (ModelState.IsValid)
            {
                repo.Update(pitanje);
                repo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SkupPitanjaId = repo.SkupPitanjaList(pitanje.SkupPitanjaId);
            ViewBag.VrstaPitanjaId = repo.VrstaPitanjaList(pitanje.VrstaPitanjaId);
            return View(pitanje);
        }

        // GET: Pitanje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pitanje pitanje = repo.FindById(id);
            if (pitanje == null)
            {
                return HttpNotFound();
            }
            return View(pitanje);
        }

        // POST: Pitanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pitanje pitanje = repo.FindById(id);
            repo.Delete(pitanje);
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
