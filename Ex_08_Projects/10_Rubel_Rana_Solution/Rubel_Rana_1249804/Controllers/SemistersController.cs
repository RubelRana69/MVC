﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rubel_Rana_1249804;
using PagedList;
using PagedList.Mvc;

namespace Rubel_Rana_1249804.Controllers
{
    [Authorize]
    public class SemistersController : Controller
    {
        private StudentDbContext db = new StudentDbContext();

        // GET: Semisters
        public ActionResult Index(int page=1)
        {
            return View(db.Semisters.OrderBy(x=>x.SemisterId).ToPagedList(page,5));
        }

        // GET: Semisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.Semisters.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // GET: Semisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semisters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemisterId,SemisterName")] Semister semister)
        {
            if (ModelState.IsValid)
            {
                db.Semisters.Add(semister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semister);
        }

        // GET: Semisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.Semisters.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // POST: Semisters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemisterId,SemisterName")] Semister semister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semister);
        }

        // GET: Semisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.Semisters.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // POST: Semisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semister semister = db.Semisters.Find(id);
            db.Semisters.Remove(semister);
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
