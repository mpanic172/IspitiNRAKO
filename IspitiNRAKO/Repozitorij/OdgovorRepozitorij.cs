using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class OdgovorRepozitorij : IRepository<Odgovor>
    {

        private IspitiEntities db;

        public OdgovorRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Odgovor> GetAll
        {
            get
            {
                var odgovors = db.Odgovors.Include(o => o.Pitanje);
                return odgovors.ToList();
            }
        }

        public void Add(Odgovor entity)
        {
            db.Odgovors.Add(entity);
        }

        public void Delete(Odgovor entity)
        {
            db.Odgovors.Remove(entity);
        }

        public Odgovor FindById(int? Id)
        {
            Odgovor odg = db.Odgovors.Find(Id);
            return odg;

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Odgovor entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList PitanjaList()
        {
            SelectList lista = new SelectList(db.Pitanjes, "IdPitanje", "Tekst");
            return lista;
        }

        public SelectList PitanjaList(int id)
        {
            SelectList lista = new SelectList(db.Pitanjes, "IdPitanje", "Tekst", id);
            return lista;
        }
    }
}