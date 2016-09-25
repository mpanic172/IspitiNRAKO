using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Repozitorij
{
    public class AdministratorRepozitorij : IRepository<Administrator>
    {
        private IspitiEntities db;

        public AdministratorRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<Administrator> GetAll
        {
            get
            {
                return db.Administrators.ToList();
            }
        }

        public void Add(Administrator entity)
        {
            db.Administrators.Add(entity);
        }

        public void Delete(Administrator entity)
        {
            db.Administrators.Remove(entity);
        }

        public Administrator FindById(int? Id)
        {
            Administrator admin = db.Administrators.Find(Id);
            return admin;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Administrator entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}