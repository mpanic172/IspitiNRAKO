using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class KorisnikRepozitorij : IRepository<Korisnik>
    {

        private IspitiEntities db;

        public KorisnikRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Korisnik> GetAll
        {
            get
            {
                var lista = db.Korisniks.Include(k => k.Kompanija).Include(k => k.Spol).Include(k => k.StrucnaSprema);
                return lista.ToList();
            }
        }

        public void Add(Korisnik entity)
        {
            db.Korisniks.Add(entity);
        }

        public void Delete(Korisnik entity)
        {
            db.Korisniks.Remove(entity);
        }

        public Korisnik FindById(int? Id)
        {
            Korisnik korisnik = db.Korisniks.Find(Id);
            return korisnik;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Korisnik entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList KompanijaList()
        {
            SelectList lista = new SelectList(db.Kompanijas, "IdKompanija", "Naziv");
            return lista;
        }

        public SelectList SpolList()
        {
            SelectList lista = new SelectList(db.Spols, "IdSpol", "Naziv");
            return lista;
        }

        public SelectList StrucnaSpremaList()
        {
            SelectList lista = new SelectList(db.StrucnaSpremas, "IdStrucnaSprema", "Naziv");
            return lista;
        }

        public SelectList KompanijaList(int id)
        {
            SelectList lista = new SelectList(db.Kompanijas, "IdKompanija", "Naziv", id);
            return lista;
        }

        public SelectList SpolList(int id)
        {
            SelectList lista = new SelectList(db.Spols, "IdSpol", "Naziv", id);
            return lista;
        }

        public SelectList StrucnaSpremaList(int id)
        {
            SelectList lista = new SelectList(db.StrucnaSpremas, "IdStrucnaSprema", "Naziv", id);
            return lista;
        }
    }
}