using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class IspitGrupaRepozitorij : IRepository<IspitGrupa>
    {

        private IspitiEntities db;

        public IspitGrupaRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<IspitGrupa> GetAll
        {
            get
            {
                var ispitGrupas = db.IspitGrupas.Include(i => i.Grupa).Include(i => i.Ispit);
                return ispitGrupas.ToList();
            }
        }

        public void Add(IspitGrupa entity)
        {
            db.IspitGrupas.Add(entity);
        }

        public void Delete(IspitGrupa entity)
        {
            db.IspitGrupas.Remove(entity);
        }

        public IspitGrupa FindById(int? Id)
        {
            IspitGrupa ig = db.IspitGrupas.Find(Id);
            return ig;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(IspitGrupa entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList GrupaLista()
        {
            SelectList lista = new SelectList(db.Grupas, "IdGrupa", "Naziv");
            return lista;
        }

        public SelectList IspitLista()
        {
            SelectList lista = new SelectList(db.Ispits, "IdIspit", "Naziv");
            return lista;
        }

        public SelectList GrupaLista(int id)
        {
            SelectList lista = new SelectList(db.Grupas, "IdGrupa", "Naziv", id);
            return lista;
        }

        public SelectList IspitLista(int id)
        {
            SelectList lista = new SelectList(db.Ispits, "IdIspit", "Naziv", id);
            return lista;
        }
    }
}