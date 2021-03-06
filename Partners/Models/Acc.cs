﻿using System;

namespace Partners.Models
{
    public class Acc
    {
        public int AccID { get; set; }
        public int CompanyID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string YearCertified { get; set; }
        public int ? PremierTrainer { get; set; }
        public int ? Select { get; set; }
        public string AccPhone { get; set; }
        public int ? Inactive { get; set; }

        public virtual Company Company { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
    }
}