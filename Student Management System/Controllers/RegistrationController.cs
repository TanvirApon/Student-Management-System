﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class RegistrationController : Controller
    {
        private StudentEntities db = new StudentEntities();

        // GET: Registration
        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Batch).Include(r => r.Course).Include(r => r.Registration1).Include(r => r.Registration2);
            List<Registration> model = registrations.ToList();
            return View(model);
        }

        // GET: Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1");
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1");
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname");
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname");
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,course_id,batch_id")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", registration.course_id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", registration.id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", registration.id);
            return View(registration);
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", registration.course_id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", registration.id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", registration.id);
            return View(registration);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,course_id,batch_id")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", registration.course_id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", registration.id);
            ViewBag.id = new SelectList(db.Registrations, "id", "firstname", registration.id);
            return View(registration);
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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
