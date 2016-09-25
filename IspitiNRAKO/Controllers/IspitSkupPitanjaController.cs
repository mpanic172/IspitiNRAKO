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
    public class IspitSkupPitanjaController : Controller
    {
        IspitSkupPitanjaRepozitorij repo = new IspitSkupPitanjaRepozitorij();

        // GET: IspitSkupPitanja
        public ActionResult Index()
        {

            return View(repo.GetAll);
        }

        // GET: IspitSkupPitanja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IspitSkupPitanja ispitSkupPitanja = repo.FindById(id);
            if (ispitSkupPitanja == null)
            {
                return HttpNotFound();
            }
            return View(ispitSkupPitanja);
        }

        // GET: IspitSkupPitanja/Create
        public ActionResult Create()
        {

            ViewBag.IspitId = repo.Ispiti();
            ViewBag.SkupPitanjaId = repo.SkupoviPitanja();

            return View();
        }

        // POST: IspitSkupPitanja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIspitSkupPitanja,UvjetProlaza,BrojPitanja,IspitId,SkupPitanjaId")] IspitSkupPitanja ispitSkupPitanja)
        {
            if (ModelState.IsValid)
            {
                repo.Add(ispitSkupPitanja);
                repo.Save();
                return RedirectToAction("Index");
            }


            ViewBag.IspitId = repo.Ispiti(ispitSkupPitanja.IspitId);
            ViewBag.SkupPitanjaId = repo.SkupoviPitanja(ispitSkupPitanja.SkupPitanjaId);

            return View(ispitSkupPitanja);
        }

        // GET: IspitSkupPitanja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IspitSkupPitanja ispitSkupPitanja = repo.FindById(id);

            if (ispitSkupPitanja == null)
            {
                return HttpNotFound();
            }

            ViewBag.IspitId = repo.Ispiti(ispitSkupPitanja.IspitId);
            ViewBag.SkupPitanjaId = repo.SkupoviPitanja(ispitSkupPitanja.SkupPitanjaId);

            return View(ispitSkupPitanja);
        }

        // POST: IspitSkupPitanja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIspitSkupPitanja,UvjetProlaza,BrojPitanja,IspitId,SkupPitanjaId")] IspitSkupPitanja ispitSkupPitanja)
        {
            if (ModelState.IsValid)
            {
                repo.Update(ispitSkupPitanja);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.IspitId = repo.Ispiti(ispitSkupPitanja.IspitId);
            ViewBag.SkupPitanjaId = repo.SkupoviPitanja(ispitSkupPitanja.SkupPitanjaId);

            return View(ispitSkupPitanja);
        }

        // GET: IspitSkupPitanja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IspitSkupPitanja ispitSkupPitanja = repo.FindById(id);
            if (ispitSkupPitanja == null)
            {
                return HttpNotFound();
            }
            return View(ispitSkupPitanja);
        }

        // POST: IspitSkupPitanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            IspitSkupPitanja ispitSkupPitanja = repo.FindById(id);
            repo.Delete(ispitSkupPitanja);
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
