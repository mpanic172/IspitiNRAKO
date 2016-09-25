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
    public class SkupPitanjaController : Controller
    {

        SkupPitanjaRepozitorij repo = new SkupPitanjaRepozitorij();

        // GET: SkupPitanja
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        // GET: SkupPitanja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkupPitanja skupPitanja = repo.FindById(id);
            if (skupPitanja == null)
            {
                return HttpNotFound();
            }
            return View(skupPitanja);
        }

        // GET: SkupPitanja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkupPitanja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSkupPitanja,Naziv")] SkupPitanja skupPitanja)
        {
            if (ModelState.IsValid)
            {
                repo.Add(skupPitanja);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(skupPitanja);
        }

        // GET: SkupPitanja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkupPitanja skupPitanja = repo.FindById(id);
            if (skupPitanja == null)
            {
                return HttpNotFound();
            }
            return View(skupPitanja);
        }

        // POST: SkupPitanja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSkupPitanja,Naziv")] SkupPitanja skupPitanja)
        {
            if (ModelState.IsValid)
            {
                repo.Update(skupPitanja);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(skupPitanja);
        }

        // GET: SkupPitanja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkupPitanja skupPitanja = repo.FindById(id);
            if (skupPitanja == null)
            {
                return HttpNotFound();
            }
            return View(skupPitanja);
        }

        // POST: SkupPitanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            SkupPitanja skupPitanja = repo.FindById(id);
            repo.Delete(skupPitanja);
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
