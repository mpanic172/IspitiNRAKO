//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class IspitGrupa
    {
        public int IdIspitGrupa { get; set; }
        public int IspitId { get; set; }
        public int GrupaId { get; set; }
    
        public virtual Grupa Grupa { get; set; }
        public virtual Ispit Ispit { get; set; }
    }
}