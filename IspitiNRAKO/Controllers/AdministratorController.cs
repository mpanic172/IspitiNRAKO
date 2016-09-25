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
    
    public class AdministratorController : Controller
    {
        
        AdministratorRepozitorij repo = new AdministratorRepozitorij();

        [LoginAdmins]
        public ActionResult Index()
        {
            
            return View(repo.GetAll);
        }

        [LoginAdmins]
        public ActionResult AdminGrupa()
        {
            return RedirectToAction("Index", "AdministratorGrupas");
        }

        [LoginUser]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Administrator administrator = repo.FindById(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        [LoginUser]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoginUser]
        public ActionResult Create([Bind(Include = "IdAdministrator,Username,Password,Ime,Prezime,Razina")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                repo.Add(administrator);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(administrator);
        }

        // GET: Administrator/Edit/5
        [LoginUser]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Administrator administrator = repo.FindById(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Administrator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoginUser]
        public ActionResult Edit([Bind(Include = "IdAdministrator,Username,Password,Ime,Prezime,Razina")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                repo.Update(administrator);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(administrator);
        }

        // GET: Administrator/Delete/5
        [LoginUser]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Administrator administrator = repo.FindById(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [LoginUser]
        public ActionResult DeleteConfirmed(int id)
        {
           
            Administrator administrator = repo.FindById(id);
            repo.Delete(administrator);
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
