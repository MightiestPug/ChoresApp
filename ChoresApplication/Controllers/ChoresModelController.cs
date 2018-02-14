using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChoresApplication.Models;

namespace ChoresApplication.Controllers
{
    public class ChoresModelController : Controller
    {
        private ChoresApplicationContext db = new ChoresApplicationContext();

        // GET: ChoresModel
        public ActionResult Index()
        {
            return View(db.ChoresModels.ToList());
        }

        // GET: ChoresModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoresModel choresModel = db.ChoresModels.Find(id);
            if (choresModel == null)
            {
                return HttpNotFound();
            }
            return View(choresModel);
        }

        // GET: ChoresModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChoresModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ChoreName,ChoreDescription")] ChoresModel choresModel)
        {
            if (ModelState.IsValid)
            {
                db.ChoresModels.Add(choresModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(choresModel);
        }

        // GET: ChoresModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoresModel choresModel = db.ChoresModels.Find(id);
            if (choresModel == null)
            {
                return HttpNotFound();
            }
            return View(choresModel);
        }

        // POST: ChoresModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ChoreName,ChoreDescription")] ChoresModel choresModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choresModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(choresModel);
        }

        // GET: ChoresModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoresModel choresModel = db.ChoresModels.Find(id);
            if (choresModel == null)
            {
                return HttpNotFound();
            }
            return View(choresModel);
        }

        // POST: ChoresModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChoresModel choresModel = db.ChoresModels.Find(id);
            db.ChoresModels.Remove(choresModel);
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
