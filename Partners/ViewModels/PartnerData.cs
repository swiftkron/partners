using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Partners.Models;

namespace Partners.ViewModels
{
    public class PartnerModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<CountryData> CountryData { get; set; }
        public IEnumerable<StateData> StateData { get; set; }
        public IEnumerable<CityData> CityData { get; set; }
        public IEnumerable<CompanyData> CompanyData { get; set; }
    }
    public class CountryData
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
    public class CityData
    {
        public int CityID { get; set; }
        public string City { get; set; }
    } 
    public class StateData
    {
        public int StateID { get; set; }
        public string State { get; set; }
        public string Abbr { get; set; }
    }
    public class CompanyData
    {
        public int CompanyID { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Tier { get; set; }
        public int UUM { get; set; }
        public string State { get; set; }
        public string Abbr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccPhone { get; set; }
        public int CityID { get; set; }
        public string City { get; set; }
        public string YearCertified { get; set; }
        public string Select { get; set; }
        public string PremierTrainer { get; set; }
        public string Inactive { get; set; }
    }
}