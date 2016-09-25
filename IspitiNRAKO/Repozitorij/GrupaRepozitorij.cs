using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class GrupaRepozitorij : IRepository<Grupa>
    {

        private IspitiEntities db;

        public GrupaRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Grupa> GetAll
        {
            get
            {
                var lista = db.Grupas.Include(g => g.Kompanija);
                return lista.ToList();
            }
        }

        public void Add(Grupa entity)
        {
            db.Grupas.Add(entity);
        }

        public void Delete(Grupa entity)
        {
            db.Grupas.Remove(entity);
        }

        public Grupa FindById(int? Id)
        {
            Grupa grupa = db.Grupas.Find(Id);
            return grupa;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Grupa entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList KompanijaLista()
        {
            SelectList lista = new SelectList(db.Kompanijas, "IdKompanija", "Naziv");
            return lista;
        }

        public SelectList KompanijaLista(int id)
        {
            SelectList lista = new SelectList(db.Kompanijas, "IdKompanija", "Naziv", id);
            return lista;
        }
    }
}