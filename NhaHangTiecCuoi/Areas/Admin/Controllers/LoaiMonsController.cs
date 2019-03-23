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
    public class LoaiMonsController : Controller
    {
        private QLNHTiecCuoiEntities db = new QLNHTiecCuoiEntities();

        // GET: Admin/LoaiMons
        public ActionResult Index()
        {
            return View(db.LoaiMons.ToList());
        }

        // GET: Admin/LoaiMons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            if (loaiMon == null)
            {
                return HttpNotFound();
            }
            return View(loaiMon);
        }

        // GET: Admin/LoaiMons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiMons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiMon loaiMon)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMons.Add(loaiMon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMon);
        }

        // GET: Admin/LoaiMons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            if (loaiMon == null)
            {
                return HttpNotFound();
            }
            return View(loaiMon);
        }

        // POST: Admin/LoaiMons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiMon loaiMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMon);
        }

        // GET: Admin/LoaiMons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            if (loaiMon == null)
            {
                return HttpNotFound();
            }
            return View(loaiMon);
        }

        // POST: Admin/LoaiMons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            db.LoaiMons.Remove(loaiMon);
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
