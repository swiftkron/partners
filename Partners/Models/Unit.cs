using System;

namespace Partners.Models
{

    public class Unit
    {
        public int UnitID { get; set; }
        public int CompanyID { get; set; }
        public int StateID { get; set; }
        public int UUM { get; set; }

        public virtual Company Company { get; set; }
        public virtual State State { get; set; }
    }
}