using IspitiNRAKO.CustomAttributes;
using IspitiNRAKO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Controllers
{

    
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View("Index");
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult TestSide()
        {
            TestPitanja testpitanja = new TestPitanja();

            TestTekst t1 = new TestTekst(1, "tekst 1");
            TestTekst t2 = new TestTekst(2, "tekst 2");
            TestTekst t3 = new TestTekst(3, "tekst 3");

            testpitanja.TestTeksts.Add(t1);
            testpitanja.TestTeksts.Add(t2);
            testpitanja.TestTeksts.Add(t3);

            ViewBag.IdTekst = 1;

            return View(testpitanja);
        }

        public ActionResult TestOpen(int? idtekst)
        {
            if (idtekst == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TestPitanja testpitanja = new TestPitanja();

            TestTekst t1 = new TestTekst(1, "tekst 1");
            TestTekst t2 = new TestTekst(2, "tekst 2");
            TestTekst t3 = new TestTekst(3, "tekst 3");

            testpitanja.TestTeksts.Add(t1);
            testpitanja.TestTeksts.Add(t2);
            testpitanja.TestTeksts.Add(t3);

            ViewBag.IdTekst = idtekst;
            
            return View(testpitanja);
        }

        public ActionResult DeleteSession()
        {
            Session.Abandon();
            Session["UserType"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void MyTest()
        {
            int a = 1;
        }
    }
}
