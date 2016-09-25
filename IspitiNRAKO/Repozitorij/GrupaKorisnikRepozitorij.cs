using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class GrupaKorisnikRepozitorij : IRepository<GrupaKorisnik>
    {

        private IspitiEntities db;

        public GrupaKorisnikRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<GrupaKorisnik> GetAll
        {
            get
            {
                var grupaKorisniks = db.GrupaKorisniks.Include(g => g.Grupa).Include(g => g.Korisnik);
                return grupaKorisniks.ToList();
            }
        }

        public void Add(GrupaKorisnik entity)
        {
            db.GrupaKorisniks.Add(entity);
        }

        public void Delete(GrupaKorisnik entity)
        {
            db.GrupaKorisniks.Remove(entity);
        }

        public GrupaKorisnik FindById(int? Id)
        {
            GrupaKorisnik gk = db.GrupaKorisniks.Find(Id);
            return gk;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(GrupaKorisnik entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList GrupaList()
        {
            SelectList lista = new SelectList(db.Grupas, "IdGrupa", "Naziv");
            return lista;
        }

        public SelectList KorisnikList()
        {
            SelectList lista = new SelectList(db.Korisniks, "IdKorisnik", "Username");
            return lista;
        }

        public SelectList GrupaList(int id)
        {
            SelectList lista = new SelectList(db.Grupas, "IdGrupa", "Naziv", id);
            return lista;
        }

        public SelectList KorisnikList(int id)
        {
            SelectList lista = new SelectList(db.Korisniks, "IdKorisnik", "Username", id);
            return lista;
        }
    }
}