﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IspitiNRAKO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IspitiEntities : DbContext
    {
        public IspitiEntities()
            : base("name=IspitiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kompanija> Kompanijas { get; set; }
        public virtual DbSet<Grupa> Grupas { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<AdministratorGrupa> AdministratorGrupas { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Spol> Spols { get; set; }
        public virtual DbSet<StrucnaSprema> StrucnaSpremas { get; set; }
        public virtual DbSet<GrupaKorisnik> GrupaKorisniks { get; set; }
        public virtual DbSet<Odgovor> Odgovors { get; set; }
        public virtual DbSet<Pitanje> Pitanjes { get; set; }
        public virtual DbSet<SkupPitanja> SkupPitanjas { get; set; }
        public virtual DbSet<VrstaPitanja> VrstaPitanjas { get; set; }
        public virtual DbSet<Ispit> Ispits { get; set; }
        public virtual DbSet<IspitSkupPitanja> IspitSkupPitanjas { get; set; }
        public virtual DbSet<IspitGrupa> IspitGrupas { get; set; }
        public virtual DbSet<Rezultat> Rezultats { get; set; }
    }
}