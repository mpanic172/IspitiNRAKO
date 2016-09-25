using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class PitanjeRepozitorij : IRepository<Pitanje>
    {

        private IspitiEntities db;

        public PitanjeRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Pitanje> GetAll
        {
            get
            {
                var pitanjes = db.Pitanjes.Include(pt => pt.SkupPitanja).Include(pt => pt.VrstaPitanja);

                return pitanjes.ToList();
            
            }
        }

        public void Add(Pitanje entity)
        {
            db.Pitanjes.Add(entity);
        }

        public void Delete(Pitanje entity)
        {
            db.Pitanjes.Remove(entity);
        }

        public Pitanje FindById(int? Id)
        {
            Pitanje p = db.Pitanjes.Find(Id);
            return p;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Pitanje entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList SkupPitanjaList()
        {
            SelectList lista = new SelectList(db.SkupPitanjas, "IdSkupPitanja", "Naziv");
            return lista;
        }

        public SelectList VrstaPitanjaList()
        {
            SelectList lista = new SelectList(db.VrstaPitanjas, "IdVrstaPitanja", "Naziv");
            return lista;
        }

        public SelectList SkupPitanjaList(int id)
        {
            SelectList lista = new SelectList(db.SkupPitanjas, "IdSkupPitanja", "Naziv", id);
            return lista;
        }

        public SelectList VrstaPitanjaList(int id)
        {
            SelectList lista = new SelectList(db.VrstaPitanjas, "IdVrstaPitanja", "Naziv", id);
            return lista;
        }
    }
}