using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Repozitorij
{
    public class KompanijaRepozitorij : IRepository<Kompanija>
    {

        private IspitiEntities db;

        public KompanijaRepozitorij()
        {
            db = new IspitiEntities();
        }

        public KompanijaRepozitorij(IspitiEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Kompanija> GetAll
        {
            get
            {
                return db.Kompanijas.ToList();
            }
        }

        public virtual List<Kompanija> GetKomps()
        {
            List<Kompanija> lista = db.Kompanijas.ToList();
            return lista;
        }

        public virtual int Count()
        {
            return db.Kompanijas.ToList().Count;
        }

        public void Add(Kompanija entity)
        {
            db.Kompanijas.Add(entity);
        }

        public void Delete(Kompanija entity)
        {
            db.Kompanijas.Remove(entity);
        }

        public virtual void Del(Kompanija entity)
        {
            db.Kompanijas.Remove(entity);
            db.SaveChanges();
        }

        public Kompanija FindById(int? Id)
        {
            Kompanija kompanija = db.Kompanijas.Find(Id);
            return kompanija;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Kompanija entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}