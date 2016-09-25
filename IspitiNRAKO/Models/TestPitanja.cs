using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IspitiNRAKO.Models
{
    public class TestPitanja
    {
        public virtual ICollection<TestTekst> TestTeksts { get; set; }

        public TestPitanja()
        {
            this.TestTeksts = new HashSet<TestTekst>();
        }

    }
}