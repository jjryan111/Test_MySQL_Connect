using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Test_MySQL_Connect.Models
{
    public class guhsController : Controller
    {
        private test_mysqlEntities db = new test_mysqlEntities();

        // GET: guhs
        public ActionResult Index()
        {
            return View(db.guhs.ToList());
        }

        // GET: guhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guh guh = db.guhs.Find(id);
            if (guh == null)
            {
                return HttpNotFound();
            }
            return View(guh);
        }

        // GET: guhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: guhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Thing1,Thing2")] guh guh)
        {
            if (ModelState.IsValid)
            {
                db.guhs.Add(guh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guh);
        }

        // GET: guhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guh guh = db.guhs.Find(id);
            if (guh == null)
            {
                return HttpNotFound();
            }
            return View(guh);
        }

        // POST: guhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Thing1,Thing2")] guh guh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guh);
        }

        // GET: guhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guh guh = db.guhs.Find(id);
            if (guh == null)
            {
                return HttpNotFound();
            }
            return View(guh);
        }

        // POST: guhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            guh guh = db.guhs.Find(id);
            db.guhs.Remove(guh);
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
