using IspitiNRAKO.Models;
using IspitiNRAKO.Repozitorij;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Controllers
{
    public class MojIspitController : Controller
    {

        private IspitiEntities db = new IspitiEntities();
        Random rnd = new Random(DateTime.Now.Millisecond);
        KorisnikRepozitorij repoKorisnik = new KorisnikRepozitorij();
        MojIspitRepozitorij repoMojIspit = new MojIspitRepozitorij();
        IspitRepozitorij repoIspit = new IspitRepozitorij();
        PitanjeRepozitorij repoPitanje = new PitanjeRepozitorij();


        // GET: MojIspit
        public ActionResult Index()
        {

            int userid = Int32.Parse(Session["UserID"].ToString());


            Korisnik korisnik = repoKorisnik.FindById(userid);


            List<Grupa> grupe = repoMojIspit.GetGrupe(userid);

            List<Ispit> ispiti = new List<Ispit>();

            foreach (Grupa grupa in grupe)
            {
                int grupaid = grupa.IdGrupa;


                List<Ispit> isp = repoMojIspit.GetIspiti(grupaid);

                ispiti.AddRange(isp);
            }

            

            return View(ispiti);
        }

        public ActionResult Start(int? id)
        {
            Ispit ispit = repoIspit.FindById(id);
            IspitManager im = StartIspit(ispit);

            if (Session["EndDate"] == null)
            {
                Session["EndDate"] = DateTime.Now.AddMinutes(ispit.Trajanje).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            ViewBag.EndDate = Session["EndDate"];

            return View(im);
            
        }

        public IspitManager StartIspit(Ispit ispit)
        {

            IspitManager im = new IspitManager();
            im.IdIspit = ispit.IdIspit;
            Session["IdIspit"] = im.IdIspit;

            foreach (IspitSkupPitanja item in ispit.IspitSkupPitanjas)
            {
                SkupPitanja skup = item.SkupPitanja;
                int broj = item.BrojPitanja;
                List<Pitanje> pitanjaStart = skup.Pitanjes.ToList();
                List<Pitanje> pitanjaEnd = pitanjaStart.OrderBy(x => rnd.Next()).Take(broj).ToList();
                foreach (Pitanje pit in pitanjaEnd)
                {
                    PitanjeManager pm = new PitanjeManager();
                    pm.Pitanje = pit;
                    pm.Odgovoreno = 0;
                    pm.Tocno = 0;
                    im.Pitanja.Add(pm);
                }
            }

            var firstElement = im.Pitanja.First();
            ViewBag.IdPitanje = firstElement.Pitanje.IdPitanje;
            Session["Ispit"] = im;
            Session["Kraj"] = 0;

            
            return im;

        }

        public ActionResult Odgovori(int? id)
        {
            IspitManager im = Session["Ispit"] as IspitManager;

            ViewBag.IdPitanje = id;
            Pitanje pitanje = repoPitanje.FindById(id);
            ViewBag.Tekst = pitanje.Tekst;

            return View(im);

        }

        [HttpPost]
        public ActionResult Odgovori(FormCollection fc)
        {

            int idPitanje = Int32.Parse(Request.Form["idPitanje"]);
            IspitManager im = Session["Ispit"] as IspitManager;

            Pitanje pitanje = repoPitanje.FindById(idPitanje);


            List<int> submitOdg = getSubmited(fc);
            

            List<int> tocniOdg = getTocni(pitanje);


            bool tocno = submitOdg.SequenceEqual(tocniOdg);

            foreach (PitanjeManager pit in im.Pitanja)
            {
                if (idPitanje == pit.Pitanje.IdPitanje)
                {
                    if (tocno)
                    {
                        pit.Tocno = 1;
                    }
                    pit.Odgovoreno = 1;
                }
            }

            Pitanje next = new Pitanje();

            foreach (PitanjeManager pit in im.Pitanja)
            {
                if (pit.Odgovoreno == 0)
                {
                    next = pit.Pitanje;
                    break;
                }
                
            }

            if (next != null)
            {
                ViewBag.IdPitanje = next.IdPitanje;
                ViewBag.Tekst = next.Tekst;
            }

            bool sveOdg = ProvjeriPitanja(im);

            if (sveOdg)
            {
                Session["Kraj"] = 1;
            }

            Session["Ispit"] = im;

            return View(im);

        }

        private List<int> getTocni(Pitanje pitanje)
        {
            List<int> tocniOdg = new List<int>();

            foreach (Odgovor odg in pitanje.Odgovors)
            {
                if (odg.Tocno == 1)
                {
                    tocniOdg.Add(odg.IdOdgovor);
                }
            }

            tocniOdg.Sort();
            return tocniOdg;
        }

        private List<int> getSubmited(FormCollection fc)
        {
            List<int> submitOdg = new List<int>();

            if (fc.Count > 1)
            {
                for (int i = 1; i < fc.Count; i++)
                {
                    submitOdg.Add(Int32.Parse(fc.AllKeys[i]));
                }
            }

            submitOdg.Sort();
            return submitOdg;

        }

        [HttpPost]
        public ActionResult Kraj(FormCollection fc)
        {

            IspitManager im = Session["Ispit"] as IspitManager;
            int brojPitanja = im.Pitanja.Count;
            Rezultat rez = new Rezultat();

            int brojTocnih = getBrojTocnih(im);


            double postotak = (double)brojTocnih / (double)brojPitanja;
            double post = postotak * 100;

            Ispit ispit = repoIspit.FindById(im.IdIspit);

            double uvjet = (double)ispit.UvjetProlaza;

            if (post >= uvjet)
            {
                ViewBag.Tekst = "Prosli ste ispit!";
                rez.Prolaz = 1;
            }
            else
            {
                ViewBag.Tekst = "Pali ste ispit!";
                rez.Prolaz = 0;
            }

            Random rnd = new Random();
            rez.IdRezultat = rnd.Next(1, 9999);

            rez.Vrijeme = DateTime.Now;
            rez.BrojBodova = brojTocnih;
            rez.Postotak = (decimal)post;
            rez.KorisnikId = Int32.Parse(Session["UserID"].ToString());
            rez.IspitId = im.IdIspit;

            db.Rezultats.Add(rez);
            db.SaveChanges();


            return View();
            
        }

        private int getBrojTocnih(IspitManager im)
        {
            int brojTocnih = 0;

            foreach (PitanjeManager item in im.Pitanja)
            {
                if (item.Tocno == 1)
                {
                    brojTocnih++;
                }
            }

            return brojTocnih;
        }

        private bool ProvjeriPitanja(IspitManager im)
        {
            int brojSve = im.Pitanja.Count;
            int brojOdg = 0;

            foreach (PitanjeManager pm in im.Pitanja)
            {
                if (pm.Odgovoreno == 1)
                {
                    brojOdg++;
                }
            }

            if (brojSve == brojOdg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}