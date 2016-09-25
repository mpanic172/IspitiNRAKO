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
    public class AdministratorGrupasController : Controller
    {
        
        AdministratorGrupaRepozitorij repo = new AdministratorGrupaRepozitorij();
        

        // GET: AdministratorGrupas
        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        // GET: AdministratorGrupas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministratorGrupa administratorGrupa = repo.FindById(id);
            if (administratorGrupa == null)
            {
                return HttpNotFound();
            }
            return View(administratorGrupa);
        }

        // GET: AdministratorGrupas/Create
        public ActionResult Create()
        {
            ViewBag.AdministratorId = repo.AdminList();
            ViewBag.GrupaId = repo.GrupaList();
            return View();
        }

        // POST: AdministratorGrupas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdministratorGrupa,AdministratorId,GrupaId")] AdministratorGrupa administratorGrupa)
        {
            if (ModelState.IsValid)
            {
                repo.Add(administratorGrupa);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AdministratorId = repo.AdminList(administratorGrupa.AdministratorId);
            ViewBag.GrupaId = repo.GrupaList(administratorGrupa.GrupaId);
            return View(administratorGrupa);
        }

        // GET: AdministratorGrupas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministratorGrupa administratorGrupa = repo.FindById(id);
            if (administratorGrupa == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministratorId = repo.AdminList(administratorGrupa.AdministratorId);
            ViewBag.GrupaId = repo.GrupaList(administratorGrupa.GrupaId);
            return View(administratorGrupa);
        }

        // POST: AdministratorGrupas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdministratorGrupa,AdministratorId,GrupaId")] AdministratorGrupa administratorGrupa)
        {
            if (ModelState.IsValid)
            {
                repo.Update(administratorGrupa);
                repo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AdministratorId = repo.AdminList(administratorGrupa.AdministratorId);
            ViewBag.GrupaId = repo.GrupaList(administratorGrupa.GrupaId);
            return View(administratorGrupa);
        }

        // GET: AdministratorGrupas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministratorGrupa administratorGrupa = repo.FindById(id);
            if (administratorGrupa == null)
            {
                return HttpNotFound();
            }
            return View(administratorGrupa);
        }

        // POST: AdministratorGrupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministratorGrupa administratorGrupa = repo.FindById(id);
            repo.Delete(administratorGrupa);
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
