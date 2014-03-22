using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaceDpsWeb.Models;

namespace PaceDpsWeb.Controllers
{
    [Authorize]
    public class Default1Controller : Controller
    {
        private Entities db = new Entities();

        // GET: /Default1/
        public ActionResult Index()
        {
            var userresearches = db.UserResearch.Include(u => u.AspNetUser);
            return View(userresearches.ToList());
        }

        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResearch userresearch = db.UserResearch.Find(id);
            if (userresearch == null)
            {
                return HttpNotFound();
            }
            return View(userresearch);
        }

        // GET: /Default1/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Description,UserId")] UserResearch userresearch)
        {
            if (ModelState.IsValid)
            {
                db.UserResearch.Add(userresearch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", userresearch.UserId);
            return View(userresearch);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResearch userresearch = db.UserResearch.Find(id);
            if (userresearch == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", userresearch.UserId);
            return View(userresearch);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Description,UserId")] UserResearch userresearch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userresearch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", userresearch.UserId);
            return View(userresearch);
        }

        // GET: /Default1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserResearch userresearch = db.UserResearch.Find(id);
            if (userresearch == null)
            {
                return HttpNotFound();
            }
            return View(userresearch);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserResearch userresearch = db.UserResearch.Find(id);
            db.UserResearch.Remove(userresearch);
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
