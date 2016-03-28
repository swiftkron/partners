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

namespace Partners.Controllers
{
    public class UnitsController : Controller
    {
        private PartnerContext db = new PartnerContext();

        // GET: Units
        public ActionResult Index()
        {
            var units = db.Units.Include(u => u.Company).Include(u => u.State);
            return View(units.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Title");
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr");
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitID,CompanyID,StateID,UUM")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Title", unit.CompanyID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr", unit.StateID);
            return View(unit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Title", unit.CompanyID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr", unit.StateID);
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitID,CompanyID,StateID,UUM")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Title", unit.CompanyID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr", unit.StateID);
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction("Index");
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
