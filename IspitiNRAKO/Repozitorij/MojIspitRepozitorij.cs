using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Repozitorij
{
    public class MojIspitRepozitorij
    {

        private IspitiEntities db;

        public MojIspitRepozitorij()
        {
            db = new IspitiEntities();
        }

        public List<Grupa> GetGrupe (int id)
        {
            var queryGrupa = from korisnikGrupa in db.GrupaKorisniks
                             where korisnikGrupa.KorisnikId == id
                             join grupa in db.Grupas on korisnikGrupa.GrupaId equals grupa.IdGrupa
                             select grupa;

            List<Grupa> grupe = queryGrupa.ToList<Grupa>();

            return grupe;
        }

        public List<Ispit> GetIspiti (int id)
        {
            var query = from grupaIspit in db.IspitGrupas
                        where grupaIspit.GrupaId == id
                        join ispit in db.Ispits on grupaIspit.IspitId equals ispit.IdIspit
                        select ispit;

            List<Ispit> isp = query.ToList<Ispit>();
            return isp;
        }

    }
}