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
    
    public partial class Pitanje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pitanje()
        {
            this.Odgovors = new HashSet<Odgovor>();
        }
    
        public int IdPitanje { get; set; }
        public string Tekst { get; set; }
        public int Tezina { get; set; }
        public int Aktivno { get; set; }
        public int VrstaPitanjaId { get; set; }
        public int SkupPitanjaId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odgovor> Odgovors { get; set; }
        public virtual SkupPitanja SkupPitanja { get; set; }
        public virtual VrstaPitanja VrstaPitanja { get; set; }
    }
}
