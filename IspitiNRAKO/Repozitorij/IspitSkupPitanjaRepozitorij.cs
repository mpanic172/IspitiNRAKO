using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class IspitSkupPitanjaRepozitorij : IRepository<IspitSkupPitanja>
    {

        private IspitiEntities db;

        public IspitSkupPitanjaRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<IspitSkupPitanja> GetAll
        {
            get
            {
                var ispitSkupPitanjas = db.IspitSkupPitanjas.Include(i => i.Ispit).Include(i => i.SkupPitanja);

                return ispitSkupPitanjas.ToList();
            }
        }

        public void Add(IspitSkupPitanja entity)
        {
            db.IspitSkupPitanjas.Add(entity);
        }

        public void Delete(IspitSkupPitanja entity)
        {
            db.IspitSkupPitanjas.Remove(entity);
        }

        public IspitSkupPitanja FindById(int? Id)
        {
            IspitSkupPitanja ik = db.IspitSkupPitanjas.Find(Id);
            return ik;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(IspitSkupPitanja entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList Ispiti()
        {
            SelectList lista = new SelectList(db.Ispits, "IdIspit", "Naziv");
            return lista;
        }

        public SelectList SkupoviPitanja()
        {
            SelectList lista = new SelectList(db.SkupPitanjas, "IdSkupPitanja", "Naziv");
            return lista;
        }

        public SelectList Ispiti(int id)
        {
            SelectList lista = new SelectList(db.Ispits, "IdIspit", "Naziv", id);
            return lista;
        }

        public SelectList SkupoviPitanja(int id)
        {
            SelectList lista = new SelectList(db.SkupPitanjas, "IdSkupPitanja", "Naziv", id);
            return lista;
        }
    }
}