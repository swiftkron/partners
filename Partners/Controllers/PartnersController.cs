﻿using System;
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
        public ActionResult Index(int? CountryID, int? StateID, int? AccType)
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

                viewModel.StateData = state_data.OrderBy(state => state.State);

            }

            // Get Partners by State order by UUM
            if (StateID != null)
            {
                var country = CountryID.Value;
                var state = StateID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companies on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              join city in db.Cities on acc.CityID equals city.CityID
                              let units = (from u in db.Units where u.StateID == state && u.CompanyID == acc.CompanyID select u.UUM).FirstOrDefault()
                              where acc.StateID == state && acc.Inactive != 1
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
                                  AccPhone = acc.AccPhone,
                                  YearCertified = acc.YearCertified,
                                  CityID = city.CityID,
                                  City = city.Name,
                                  Abbr = st.Abbr
                              }).ToList();

                var my_country = (from ctry in db.Countries
                                where ctry.CountryID == country
                                select new CountryData{
                                    CountryName = ctry.CountryName
                                }).ToList();

                var my_state = (from st in db.States where st.StateID == state select new StateData{
                    State = st.Name,
                }).ToList();

                var my_cities = (from city in db.Cities
                                 join st in db.States on city.StateID equals st.StateID
                                 where city.StateID == state
                                  select new CityData
                                  {
                                      CityID = city.CityID,
                                      City = city.Name
                                  }).ToList();

                viewModel.CountryData = my_country;
                viewModel.StateData = my_state;
                viewModel.CityData = my_cities;
                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Partners by Select Certification
            if ((StateID == null) && (AccType == 1))
            {
                //var country = CountryID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companies on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              join city in db.Cities on acc.CityID equals city.CityID
                              where acc.Select == 1 && acc.Inactive != 1
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
                                  AccPhone = acc.AccPhone,
                                  YearCertified = acc.YearCertified,
                                  CityID = city.CityID,
                                  City = city.Name,
                                  Abbr = st.Abbr
                              }).ToList();

                //var my_country = (from ctry in db.Countries
                //                  where ctry.CountryID == country
                //                  select new CountryData
                //                  {
                //                      CountryName = ctry.CountryName
                //                  }).ToList();

                //viewModel.CountryData = my_country;
                viewModel.StateData = null;
                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Partners by Select Certification by State
            if ((StateID != null) && (AccType == 1))
            {
                var state = StateID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companies on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              join city in db.Cities on acc.CityID equals city.CityID
                              let units = (from u in db.Units where u.StateID == state && u.CompanyID == acc.CompanyID select u.UUM).FirstOrDefault()
                              where acc.StateID == state && acc.Select == 1 && acc.Inactive != 1
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
                                  AccPhone = acc.AccPhone,
                                  YearCertified = acc.YearCertified,
                                  CityID = city.CityID,
                                  City = city.Name,
                                  Abbr = st.Abbr
                              }).ToList();


                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Premier Trainers
            if ((StateID == null) && (AccType == 2))
            {
                //var country = CountryID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companies on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              join city in db.Cities on acc.CityID equals city.CityID
                              where acc.PremierTrainer == 1 && acc.Inactive != 1
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
                                  AccPhone = acc.AccPhone,
                                  YearCertified = acc.YearCertified,
                                  CityID = city.CityID,
                                  City = city.Name,
                                  Abbr = st.Abbr
                              }).ToList();

                //var my_country = (from ctry in db.Countries
                //                  where ctry.CountryID == country
                //                  select new CountryData
                //                  {
                //                      CountryName = ctry.CountryName
                //                  }).ToList();

                //viewModel.CountryData = my_country;
                viewModel.StateData = null;
                viewModel.CompanyData = c_data.OrderByDescending(c => c.UUM);

            }

            // Get Premier Trainers by State
            if ((StateID != null) && (AccType == 2))
            {
                var state = StateID.Value;
                var c_data = (from acc in db.Accs
                              join co in db.Companies on acc.CompanyID equals co.CompanyID
                              join st in db.States on acc.StateID equals st.StateID
                              join city in db.Cities on acc.CityID equals city.CityID
                              let units = (from u in db.Units where u.StateID == state && u.CompanyID == acc.CompanyID select u.UUM).FirstOrDefault()
                              where acc.StateID == state && acc.PremierTrainer == 1 && acc.Inactive != 1
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
                                  AccPhone = acc.AccPhone,
                                  YearCertified = acc.YearCertified,
                                  CityID = city.CityID,
                                  City = city.Name,
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
