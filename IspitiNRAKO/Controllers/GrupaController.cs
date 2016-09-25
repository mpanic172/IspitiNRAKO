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
    public class GrupaController : Controller
    {
        GrupaRepozitorij repo = new GrupaRepozitorij();

        // GET: Grupa
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        // GET: Grupa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = repo.FindById(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // GET: Grupa/Create
        public ActionResult Create()
        {
            ViewBag.KompanijaId = repo.KompanijaLista();
            return View();
        }

        // POST: Grupa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupa,Naziv,KompanijaId")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                repo.Add(grupa);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.KompanijaId = repo.KompanijaLista(grupa.KompanijaId);
            return View(grupa);
        }

        // GET: Grupa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = repo.FindById(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompanijaId = repo.KompanijaLista(grupa.KompanijaId);
            return View(grupa);
        }

        // POST: Grupa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupa,Naziv,KompanijaId")] Grupa grupa)
        {
            if (ModelState.IsValid)
            {
                repo.Update(grupa);
                repo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.KompanijaId = repo.KompanijaLista(grupa.KompanijaId);
            return View(grupa);
        }

        // GET: Grupa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupa grupa = repo.FindById(id);
            if (grupa == null)
            {
                return HttpNotFound();
            }
            return View(grupa);
        }

        // POST: Grupa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupa grupa = repo.FindById(id);
            repo.Delete(grupa);
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
