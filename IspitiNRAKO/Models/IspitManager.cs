using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Models
{
    public class IspitManager
    {

        public IspitManager()
        {
            this.Pitanja = new HashSet<PitanjeManager>();
        }

        public int IdIspit { get; set; }
        public virtual ICollection<PitanjeManager> Pitanja { get; set; }
    }
}