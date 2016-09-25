using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Models
{
    public class TestTekst
    {

        public int IdTekst { get; set; }
        public string Tekst { get; set; }

        public TestTekst(int id, string t)
        {
            this.IdTekst = id;
            this.Tekst = t;
        }
    }
}