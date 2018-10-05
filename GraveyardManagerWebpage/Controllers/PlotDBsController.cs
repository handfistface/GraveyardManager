using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraveyardManagerWebpage.Models;

namespace GraveyardManagerWebpage.Controllers
{
    public class PlotDBsController : Controller
    {
        private PlotDBContext db = new PlotDBContext();

        #region public ActionResult Index()
        // GET: PlotDBs
        public ActionResult Index()
        {
            return View(db.graves.ToList());
        }
        #endregion

        #region public ActionResult Details(int? id)
        // GET: PlotDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlotDB plotDB = db.graves.Find(id);
            if (plotDB == null)
            {
                return HttpNotFound();
            }
            return View(plotDB);
        }
        #endregion

        #region public ActionResult Create()
        // GET: PlotDBs/Create
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region public ActionResult Create([Bind(Include = "ID")] PlotDB plotDB)
        // POST: PlotDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] PlotDB plotDB)
        {
            if (ModelState.IsValid)
            {
                db.graves.Add(plotDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plotDB);
        }
        #endregion

        #region public ActionResult Edit(int? id)
        // GET: PlotDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlotDB plotDB = db.graves.Find(id);
            if (plotDB == null)
            {
                return HttpNotFound();
            }
            return View(plotDB);
        }
        #endregion

        #region public ActionResult Edit([Bind(Include = "ID")] PlotDB plotDB)
        // POST: PlotDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] PlotDB plotDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plotDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plotDB);
        }
        #endregion

        #region public ActionResult Delete(int? id)
        // GET: PlotDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlotDB plotDB = db.graves.Find(id);
            if (plotDB == null)
            {
                return HttpNotFound();
            }
            return View(plotDB);
        }
        #endregion

        #region public ActionResult DeleteConfirmed(int id)
        // POST: PlotDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlotDB plotDB = db.graves.Find(id);
            db.graves.Remove(plotDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region protected override void Dispose(bool disposing)
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
