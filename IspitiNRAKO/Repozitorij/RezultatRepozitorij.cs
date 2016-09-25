using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Repozitorij
{
    public class RezultatRepozitorij : IRepository<Rezultat>
    {

        private IspitiEntities db;

        public RezultatRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Rezultat> GetAll
        {
            get
            {
                var rezultats = db.Rezultats.Include(r => r.Ispit).Include(r => r.Korisnik);
                return rezultats.ToList();
            }
        }

        public IEnumerable<Rezultat> GetRezultati(int id)
        {
            var rezultats = db.Rezultats.Include(r => r.Ispit).Include(r => r.Korisnik).Where(k => k.KorisnikId == id);
            return rezultats.ToList();
        }

        public void Add(Rezultat entity)
        {
            db.Rezultats.Add(entity);
        }

        public void Delete(Rezultat entity)
        {
            db.Rezultats.Remove(entity);
        }

        public Rezultat FindById(int? Id)
        {
            Rezultat rez = db.Rezultats.Find(Id);
            return rez;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Rezultat entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}