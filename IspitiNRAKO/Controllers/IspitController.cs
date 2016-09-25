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
    public class IspitController : Controller
    {
        IspitRepozitorij repo = new IspitRepozitorij();

        // GET: Ispit
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        // GET: Ispit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = repo.FindById(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // GET: Ispit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ispit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIspit,Naziv,Datum,Trajanje,UvjetProlaza")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                repo.Add(ispit);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(ispit);
        }

        // GET: Ispit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = repo.FindById(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIspit,Naziv,Datum,Trajanje,UvjetProlaza")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                repo.Update(ispit);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(ispit);
        }

        // GET: Ispit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = repo.FindById(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Ispit ispit = repo.FindById(id);
            repo.Delete(ispit);
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
