using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Partners.Models
{
    public class City
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string Name { get; set; }

        public virtual State State { get; set; }
    }
}