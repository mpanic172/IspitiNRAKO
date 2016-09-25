using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Repozitorij
{
    public class IspitRepozitorij : IRepository<Ispit>
    {

        private IspitiEntities db;

        public IspitRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Ispit> GetAll
        {
            get
            {
                return db.Ispits.ToList();
            }
        }

        public void Add(Ispit entity)
        {
            db.Ispits.Add(entity);
        }

        public void Delete(Ispit entity)
        {
            db.Ispits.Remove(entity);
        }

        public Ispit FindById(int? Id)
        {
            Ispit ispit = db.Ispits.Find(Id);
            return ispit;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Ispit entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}