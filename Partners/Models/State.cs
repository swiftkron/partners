using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Partners.Models
{
    public class State
    {
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string Abbr { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}