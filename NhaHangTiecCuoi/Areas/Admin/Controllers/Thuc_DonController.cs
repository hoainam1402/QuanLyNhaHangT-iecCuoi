using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaHangTiecCuoi;

namespace NhaHangTiecCuoi.Areas.Admin.Controllers
{
    public class Thuc_DonController : Controller
    {
        private QLNHTiecCuoiEntities db = new QLNHTiecCuoiEntities();

        // GET: Admin/Thuc_Don
        public ActionResult Index()
        {
            return View(db.Thuc_Don.ToList());
        }

        // GET: Admin/Thuc_Don/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuc_Don thuc_Don = db.Thuc_Don.Find(id);
            if (thuc_Don == null)
            {
                return HttpNotFound();
            }
            return View(thuc_Don);
        }

        // GET: Admin/Thuc_Don/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Thuc_Don/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTD,SoLuong,DonGia")] Thuc_Don thuc_Don)
        {
            if (ModelState.IsValid)
            {
                db.Thuc_Don.Add(thuc_Don);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuc_Don);
        }

        // GET: Admin/Thuc_Don/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuc_Don thuc_Don = db.Thuc_Don.Find(id);
            if (thuc_Don == null)
            {
                return HttpNotFound();
            }
            return View(thuc_Don);
        }

        // POST: Admin/Thuc_Don/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTD,SoLuong,DonGia")] Thuc_Don thuc_Don)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuc_Don).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuc_Don);
        }

        // GET: Admin/Thuc_Don/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuc_Don thuc_Don = db.Thuc_Don.Find(id);
            if (thuc_Don == null)
            {
                return HttpNotFound();
            }
            return View(thuc_Don);
        }

        // POST: Admin/Thuc_Don/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thuc_Don thuc_Don = db.Thuc_Don.Find(id);
            db.Thuc_Don.Remove(thuc_Don);
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
