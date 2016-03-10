using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Partners.DAL;
using Partners.Models;
using Partners.ViewModels;

namespace Partners.Controllers
{
    public class PartnersController : Controller
    {
        private PartnerContext db = new PartnerContext();

        // GET: State
        public ActionResult Index(int? CountryID, int? StateID, int? Select, int? PremierTrainer)
        {
            var viewModel = new PartnerModel();

            // Get States List by Country
            viewModel.Countries = db.Countries;

            if (CountryID != null)
            {
                var country = CountryID.Value;

                var state_data = (from state in db.States where state.CountryID == country select new StateData {
                    StateID = state.StateID,
                    State = state.Name,
                    Abbr = state.Abbr
                }).ToList();

                viewModel.StateData = state_data;
                
                var ctry_data = (from acc in db.Accs
                                 join co in db.Companys on acc.CompanyID equals co.CompanyID
                                 join state in db.States on acc.StateID equals state.StateID
                                 join ctry in db.Countries on state.CountryID equals ctry.CountryID                                 
                                 where ctry.CountryID == country
                                 select new CountryData
                                 {
                                     CompanyID = co.CompanyID,
                                     Company = co.Title,
                                     Website = co.Website,
                                     Phone = co.Phone,
                                     Tier = co.Tier,
                                     FirstName = acc.FirstName,
                                     LastName = acc.LastName,
                                     Email = acc.Email,
                                     YearCertified = acc.YearCertified,
                                     City = acc.City,
                                     StateID = state.StateID,
                                     State = state.Name,
                                     Abbr = state.Abbr
                                 }).ToList();

                viewModel.CountryData = ctry_data;

            }

            // Get Partners by State order by UUM
            if (StateID != null)
            {
                var state = StateID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companys on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              let units = (from u in db.Units where u.StateID == state && u.CompanyID == acc.CompanyID select u.UUM).FirstOrDefault()
                              where acc.StateID == state
                              select new CompanyData
                              {
                                  CompanyID = co.CompanyID,
                                  Company = co.Title,
                                  Website = co.Website,
                                  Phone = co.Phone,
                                  Tier = co.Tier,
                                  UUM = units,
                                  FirstName = acc.FirstName,
                                  LastName = acc.LastName,
                                  Email = acc.Email,
                                  YearCertified = acc.YearCertified,
                                  City = acc.City,
                                  Abbr = st.Abbr
                              }).ToList();


                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Partners by Select Certification
            if (Select == 1)
            {
                var c_data = (from acc in db.Accs
                              join co in db.Companys on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              where acc.Select == 1
                              select new CompanyData
                              {
                                  CompanyID = co.CompanyID,
                                  Company = co.Title,
                                  Website = co.Website,
                                  Phone = co.Phone,
                                  Tier = co.Tier,
                                  FirstName = acc.FirstName,
                                  LastName = acc.LastName,
                                  Email = acc.Email,
                                  YearCertified = acc.YearCertified,
                                  City = acc.City,
                                  Abbr = st.Abbr
                              }).ToList();


                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Partners by Select Certification by State
            if ((StateID != null) && (Select == 1))
            {
                var state = StateID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companys on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              let units = (from u in db.Units where u.StateID == state && u.CompanyID == acc.CompanyID select u.UUM).FirstOrDefault()
                              where acc.StateID == state && acc.Select == 1
                              select new CompanyData
                              {
                                  CompanyID = co.CompanyID,
                                  Company = co.Title,
                                  Website = co.Website,
                                  Phone = co.Phone,
                                  Tier = co.Tier,
                                  UUM = units,
                                  FirstName = acc.FirstName,
                                  LastName = acc.LastName,
                                  Email = acc.Email,
                                  YearCertified = acc.YearCertified,
                                  City = acc.City,
                                  Abbr = st.Abbr
                              }).ToList();


                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Premier Trainers
            if (PremierTrainer == 1)
            {
                var c_data = (from acc in db.Accs
                              join co in db.Companys on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              where acc.PremierTrainer == 1
                              select new CompanyData
                              {
                                  CompanyID = co.CompanyID,
                                  Company = co.Title,
                                  Website = co.Website,
                                  Phone = co.Phone,
                                  Tier = co.Tier,
                                  FirstName = acc.FirstName,
                                  LastName = acc.LastName,
                                  Email = acc.Email,
                                  YearCertified = acc.YearCertified,
                                  City = acc.City,
                                  Abbr = st.Abbr
                              }).ToList();


                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Premier Trainers by State
            if ((StateID != null) && (PremierTrainer == 1))
            {
                var state = StateID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companys on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              let units = (from u in db.Units where u.StateID == state && u.CompanyID == acc.CompanyID select u.UUM).FirstOrDefault()
                              where acc.StateID == state && acc.PremierTrainer == 1
                              select new CompanyData
                              {
                                  CompanyID = co.CompanyID,
                                  Company = co.Title,
                                  Website = co.Website,
                                  Phone = co.Phone,
                                  Tier = co.Tier,
                                  UUM = units,
                                  FirstName = acc.FirstName,
                                  LastName = acc.LastName,
                                  Email = acc.Email,
                                  YearCertified = acc.YearCertified,
                                  City = acc.City,
                                  Abbr = st.Abbr
                              }).ToList();


                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
