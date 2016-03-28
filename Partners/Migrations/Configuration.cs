namespace Partners.Migrations
{
    using Partners.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Partners.DAL.PartnerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Partners.DAL.PartnerContext context)
        {
            var countries = new List<Country>
            {
                new Country {CountryName = "United States"},
                new Country {CountryName = "Canada"},
                new Country {CountryName = "Puerto Rico"},
                new Country {CountryName = "Australia"},
                new Country {CountryName = "Belgium"},
                new Country {CountryName = "China"},
                new Country {CountryName = "Denmark"},
                new Country {CountryName = "France"},
                new Country {CountryName = "Germany"},
                new Country {CountryName = "Greece"},
                new Country {CountryName = "Hungary"},
                new Country {CountryName = "India"},
                new Country {CountryName = "Ireland"},
                new Country {CountryName = "Italy"},
                new Country {CountryName = "Netherlands"},
                new Country {CountryName = "New Zealand"},
                new Country {CountryName = "Phillipines"},
                new Country {CountryName = "Poland"},
                new Country {CountryName = "Singapore"},
                new Country {CountryName = "South Africa"},
                new Country {CountryName = "Sweden"},
                new Country {CountryName = "Switzerland"},
                new Country {CountryName = "Tunisia"},
                new Country {CountryName = "Turkey"},
                new Country {CountryName = "United Arab Emirates"},
                new Country {CountryName = "United Kingdom"}
            };
            countries.ForEach(s => context.Countries.AddOrUpdate(p => p.CountryName, s));
            context.SaveChanges();


            var states = new List<State>
            {
                new State {Abbr = "AL", Name = "Alabama", CountryID=1},
                new State {Abbr = "AZ", Name = "Arizona", CountryID=1},
                new State {Abbr = "CA", Name = "California", CountryID=1},
                new State {Abbr = "CO", Name = "Colorado", CountryID=1},
                new State {Abbr = "CT", Name = "Connecticut", CountryID=1},
                new State {Abbr = "FL", Name = "Florida", CountryID=1},
                new State {Abbr = "GA", Name = "Georgia", CountryID=1},
                new State {Abbr = "IA", Name = "Iowa", CountryID=1},
                new State {Abbr = "IL", Name = "Illinois", CountryID=1},
                new State {Abbr = "IN", Name = "Indiana", CountryID=1},
                new State {Abbr = "KS", Name = "Kansas", CountryID=1},
                new State {Abbr = "KY", Name = "Kentucky", CountryID=1},
                new State {Abbr = "LA", Name = "Louisiana", CountryID=1},
                new State {Abbr = "MA", Name = "Massachussets", CountryID=1},
                new State {Abbr = "MD", Name = "Maryland", CountryID=1},
                new State {Abbr = "MI", Name = "Michigan", CountryID=1},
                new State {Abbr = "MN", Name = "Minnesota", CountryID=1},
                new State {Abbr = "MO", Name = "Missouri", CountryID=1},
                new State {Abbr = "MT", Name = "Montana", CountryID=1},
                new State {Abbr = "NC", Name = "North Carolina", CountryID=1},
                new State {Abbr = "NH", Name = "New Hampshire", CountryID=1},
                new State {Abbr = "NJ", Name = "New Jersey", CountryID=1},
                new State {Abbr = "NY", Name = "New York", CountryID=1},
                new State {Abbr = "OH", Name = "Ohio", CountryID=1},
                new State {Abbr = "OR", Name = "Oregon", CountryID=1},
                new State {Abbr = "PA", Name = "Pennsylvania", CountryID=1},
                new State {Abbr = "RI", Name = "Rhode Island", CountryID=1},
                new State {Abbr = "TN", Name = "Tennessee", CountryID=1},
                new State {Abbr = "TX", Name = "Texas", CountryID=1},
                new State {Abbr = "UT", Name = "Utah", CountryID=1},
                new State {Abbr = "VA", Name = "Virginia", CountryID=1},
                new State {Abbr = "VI", Name = "U.S. Virgin Islands", CountryID=1},
                new State {Abbr = "VT", Name = "Vermont", CountryID=1},
                new State {Abbr = "WA", Name = "Washington", CountryID=1},
                new State {Abbr = "WI", Name = "Wisconsin", CountryID=1},
                new State {Abbr = "WV", Name = "West Virginia", CountryID=1},
                new State {Abbr = "ON", Name = "Ontario", CountryID=2},
                new State {Abbr = "QC", Name = "Quebec", CountryID=2},
                new State {Abbr = "AUCK", Name = "Auckland", CountryID=16},
                new State {Abbr = "BP", Name = "Bay of Plenty", CountryID=16},
                new State {Abbr = "NSW", Name = "New South Wales", CountryID=4},
                new State {Abbr = "QLD", Name = "Queensland", CountryID=4},
                new State {Abbr = "SA", Name = "South Australia", CountryID=4},
                new State {Abbr = "VIC", Name = "Victoria", CountryID=4},
                new State {Abbr = "WAU", Name = "Western Australia", CountryID=4}
            };
            states.ForEach(s => context.States.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


        }
    }
}