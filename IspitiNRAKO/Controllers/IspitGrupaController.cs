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
    public class IspitGrupaController : Controller
    {
        IspitGrupaRepozitorij repo = new IspitGrupaRepozitorij();

        // GET: IspitGrupa
        public ActionResult Index()
        {

            return View(repo.GetAll);
        }

        // GET: IspitGrupa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IspitGrupa ispitGrupa = repo.FindById(id);
            if (ispitGrupa == null)
            {
                return HttpNotFound();
            }
            return View(ispitGrupa);
        }

        // GET: IspitGrupa/Create
        public ActionResult Create()
        {

            ViewBag.GrupaId = repo.GrupaLista();
            ViewBag.IspitId = repo.IspitLista();
            return View();
        }

        // POST: IspitGrupa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIspitGrupa,IspitId,GrupaId")] IspitGrupa ispitGrupa)
        {
            if (ModelState.IsValid)
            {
                repo.Add(ispitGrupa);
                repo.Save();
                return RedirectToAction("Index");
            }


            ViewBag.GrupaId = repo.GrupaLista(ispitGrupa.GrupaId);
            ViewBag.IspitId = repo.IspitLista(ispitGrupa.IspitId);

            return View(ispitGrupa);
        }

        // GET: IspitGrupa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IspitGrupa ispitGrupa = repo.FindById(id);

            if (ispitGrupa == null)
            {
                return HttpNotFound();
            }

            ViewBag.GrupaId = repo.GrupaLista(ispitGrupa.GrupaId);
            ViewBag.IspitId = repo.IspitLista(ispitGrupa.IspitId);

            return View(ispitGrupa);
        }

        // POST: IspitGrupa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIspitGrupa,IspitId,GrupaId")] IspitGrupa ispitGrupa)
        {
            if (ModelState.IsValid)
            {
                repo.Update(ispitGrupa);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GrupaId = repo.GrupaLista(ispitGrupa.GrupaId);
            ViewBag.IspitId = repo.IspitLista(ispitGrupa.IspitId);

            return View(ispitGrupa);
        }

        // GET: IspitGrupa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IspitGrupa ispitGrupa = repo.FindById(id);
            if (ispitGrupa == null)
            {
                return HttpNotFound();
            }
            return View(ispitGrupa);
        }

        // POST: IspitGrupa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IspitGrupa ispitGrupa = repo.FindById(id);
            repo.Delete(ispitGrupa);
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
