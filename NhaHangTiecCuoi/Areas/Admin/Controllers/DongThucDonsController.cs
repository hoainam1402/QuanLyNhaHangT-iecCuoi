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
    public class DongThucDonsController : Controller
    {
        private QLNHTiecCuoiEntities db = new QLNHTiecCuoiEntities();

        // GET: Admin/DongThucDons
        public ActionResult Index()
        {
            var dongThucDons = db.DongThucDons.Include(d => d.MonAn).Include(d => d.Thuc_Don);
            return View(dongThucDons.ToList());
        }

        // GET: Admin/DongThucDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongThucDon dongThucDon = db.DongThucDons.Find(id);
            if (dongThucDon == null)
            {
                return HttpNotFound();
            }
            return View(dongThucDon);
        }

        // GET: Admin/DongThucDons/Create
        public ActionResult Create()
        {
            ViewBag.MaMA = new SelectList(db.MonAns, "MaMon", "TenMon");
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "MaTD");
            return View();
        }

        // POST: Admin/DongThucDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMA,MaTD,Soluong")] DongThucDon dongThucDon)
        {
            if (ModelState.IsValid)
            {
                db.DongThucDons.Add(dongThucDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMA = new SelectList(db.MonAns, "MaMon", "TenMon", dongThucDon.MaMA);
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "MaTD", dongThucDon.MaTD);
            return View(dongThucDon);
        }

        // GET: Admin/DongThucDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongThucDon dongThucDon = db.DongThucDons.Find();
            if (dongThucDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMA = new SelectList(db.MonAns, "MaMon", "TenMon", dongThucDon.MaMA);
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "MaTD", dongThucDon.MaTD);
            return View(dongThucDon);
        }

        // POST: Admin/DongThucDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMA,MaTD,Soluong")] DongThucDon dongThucDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dongThucDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMA = new SelectList(db.MonAns, "MaMon", "TenMon", dongThucDon.MaMA);
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "MaTD", dongThucDon.MaTD);
            return View(dongThucDon);
        }

        // GET: Admin/DongThucDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongThucDon dongThucDon = db.DongThucDons.Find(id);
            if (dongThucDon == null)
            {
                return HttpNotFound();
            }
            return View(dongThucDon);
        }

        // POST: Admin/DongThucDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DongThucDon dongThucDon = db.DongThucDons.Find(id);
            db.DongThucDons.Remove(dongThucDon);
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
