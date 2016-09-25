using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Repozitorij
{
    public class SkupPitanjaRepozitorij : IRepository<SkupPitanja>
    {

        private IspitiEntities db;

        public SkupPitanjaRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<SkupPitanja> GetAll
        {
            get
            {
                return db.SkupPitanjas.ToList();
            }
        }

        public void Add(SkupPitanja entity)
        {
            db.SkupPitanjas.Add(entity);
        }

        public void Delete(SkupPitanja entity)
        {
            db.SkupPitanjas.Remove(entity);
        }

        public SkupPitanja FindById(int? Id)
        {
            SkupPitanja sp = db.SkupPitanjas.Find(Id);
            return sp;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(SkupPitanja entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}