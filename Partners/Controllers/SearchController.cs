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
    public class SearchController : Controller
    {
        private PartnerContext db = new PartnerContext();

        // GET: State
        public ActionResult Index(int? CountryID, int? StateID)
        {
            var viewModel = new PartnerModel();

            // Get States List by Country
            viewModel.Countries = db.Countries;

            if (CountryID != null)
            {
                var country = CountryID.Value;

                var state_data = (from state in db.States
                                  where state.CountryID == country
                                  select new StateData
                                  {
                                      StateID = state.StateID,
                                      State = state.Name,
                                      Abbr = state.Abbr
                                  }).ToList();

                viewModel.StateData = state_data.OrderBy(state => state.State);

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
