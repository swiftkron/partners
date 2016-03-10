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
    public class AccsController : Controller
    {
        private PartnerContext db = new PartnerContext();

        // GET: Accs
        public ActionResult Index()
        {
            var accs = db.Accs.Include(a => a.Company).Include(a => a.State);
            return View(accs.ToList());
        }

        // GET: Accs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acc acc = db.Accs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            return View(acc);
        }

        // GET: Accs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companys, "CompanyID", "Title");
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr");
            return View();
        }

        // POST: Accs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccID,CompanyID,StateID,FirstName,LastName,Email,City,YearCertified")] Acc acc)
        {
            if (ModelState.IsValid)
            {
                db.Accs.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companys, "CompanyID", "Title", acc.CompanyID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr", acc.StateID);
            return View(acc);
        }

        // GET: Accs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acc acc = db.Accs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companys, "CompanyID", "Title", acc.CompanyID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr", acc.StateID);
            return View(acc);
        }

        // POST: Accs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccID,CompanyID,StateID,FirstName,LastName,Email,City,YearCertified")] Acc acc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companys, "CompanyID", "Title", acc.CompanyID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Abbr", acc.StateID);
            return View(acc);
        }

        // GET: Accs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acc acc = db.Accs.Find(id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            return View(acc);
        }

        // POST: Accs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acc acc = db.Accs.Find(id);
            db.Accs.Remove(acc);
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
