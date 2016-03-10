using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Partners.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Title { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Tier { get; set; }

        public virtual IEnumerable<Acc> Accs { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}