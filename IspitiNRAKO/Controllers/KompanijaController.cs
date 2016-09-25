using IspitiNRAKO.CustomAttributes;
using IspitiNRAKO.Repozitorij;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Controllers
{
    [LoginUser]
    public class KompanijaController : Controller
    {

        KompanijaRepozitorij repo = new KompanijaRepozitorij();
        
        // GET: Kompanija
        public ActionResult Index()
        {
            return View("Index", repo.GetAll);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kompanija kompanija = repo.FindById(id);
            if (kompanija == null)
            {
                return HttpNotFound();
            }

            return View("Details", kompanija);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create", new Kompanija());
        }

        [HttpPost]
        public ActionResult Create(Kompanija kompanija)
        {
            if (ModelState.IsValid)
            {
                repo.Add(kompanija);
                repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", kompanija);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kompanija kompanija = repo.FindById(id);
            if (kompanija == null)
            {
                return HttpNotFound();
            }
            return View(kompanija);
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Kompanija komp)
        {
            try
            {
                // TODO: Add delete logic here
                Kompanija kompanija = new Kompanija();
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    kompanija = repo.FindById(id);
                    if (kompanija == null)
                    {
                        return HttpNotFound();
                    }
                    repo.Delete(kompanija);
                    repo.Save();
                    return RedirectToAction("Index");
                }
                return View(kompanija);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kompanija k = repo.FindById(id);
            if (k == null)
            {
                return HttpNotFound();
            }
            return View("Edit", k);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKompanija,Naziv")] Kompanija kompanija)
        {
            if (ModelState.IsValid)
            {
                repo.Update(kompanija);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(kompanija);
        }
    }
}