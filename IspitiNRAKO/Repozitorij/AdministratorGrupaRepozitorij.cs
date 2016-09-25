using IspitiNRAKO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IspitiNRAKO.Repozitorij
{
    public class AdministratorGrupaRepozitorij : IRepository<AdministratorGrupa>
    {

        private IspitiEntities db;

        public AdministratorGrupaRepozitorij()
        {
            db = new IspitiEntities();
        }

        public IEnumerable<AdministratorGrupa> GetAll
        {
            get
            {
                var administratorGrupas = db.AdministratorGrupas.Include(a => a.Administrator).Include(a => a.Grupa);
                return administratorGrupas.ToList();
            }
        }

        public void Add(AdministratorGrupa entity)
        {
            db.AdministratorGrupas.Add(entity);
        }

        public void Delete(AdministratorGrupa entity)
        {
            db.AdministratorGrupas.Remove(entity);
        }

        public AdministratorGrupa FindById(int? Id)
        {
            AdministratorGrupa ag = db.AdministratorGrupas.Find(Id);
            return ag;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(AdministratorGrupa entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public SelectList AdminList()
        {
            SelectList lista = new SelectList(db.Administrators, "IdAdministrator", "Username");
            return lista;
        }

        public SelectList GrupaList()
        {
            SelectList lista = new SelectList(db.Grupas, "IdGrupa", "Naziv");
            return lista;
        }

        public SelectList AdminList(int id)
        {
            SelectList lista = new SelectList(db.Administrators, "IdAdministrator", "Username", id);
            return lista;
        }

        public SelectList GrupaList(int id)
        {
            SelectList lista = new SelectList(db.Grupas, "IdGrupa", "Naziv", id);
            return lista;
        }

    }
}