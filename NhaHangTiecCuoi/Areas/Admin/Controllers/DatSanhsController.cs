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
    public class DatSanhsController : Controller
    {
        private QLNHTiecCuoiEntities db = new QLNHTiecCuoiEntities();

        // GET: Admin/DatSanhs
        public ActionResult Index()
        {
            var datSanhs = db.DatSanhs.Include(d => d.DichVu).Include(d => d.Sanh).Include(d => d.Thuc_Don);
            return View(datSanhs.ToList());
        }

        // GET: Admin/DatSanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatSanh datSanh = db.DatSanhs.Find(id);
            if (datSanh == null)
            {
                return HttpNotFound();
            }
            return View(datSanh);
        }

        // GET: Admin/DatSanhs/Create
        public ActionResult Create()
        {
            ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV");
            ViewBag.MaSanh = new SelectList(db.Sanhs, "MaSanh", "TenSanh");
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "SoLuong");
            return View();
        }

        // POST: Admin/DatSanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDatSanh,TenKhachHang,SDTKhach,NgayDat,MaSanh,NgayThanhToan,MaTD,MaDV,Ca")] DatSanh datSanh)
        {
            if (ModelState.IsValid)
            {
                db.DatSanhs.Add(datSanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV", datSanh.MaDV);
            ViewBag.MaSanh = new SelectList(db.Sanhs, "MaSanh", "TenSanh", datSanh.MaSanh);
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "SoLuong", datSanh.MaTD);
            return View(datSanh);
        }

        // GET: Admin/DatSanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatSanh datSanh = db.DatSanhs.Find(id);
            if (datSanh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV", datSanh.MaDV);
            ViewBag.MaSanh = new SelectList(db.Sanhs, "MaSanh", "TenSanh", datSanh.MaSanh);
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "SoLuong", datSanh.MaTD);
            return View(datSanh);
        }

        // POST: Admin/DatSanhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDatSanh,TenKhachHang,SDTKhach,NgayDat,MaSanh,NgayThanhToan,MaTD,MaDV,Ca")] DatSanh datSanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datSanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDV = new SelectList(db.DichVus, "MaDV", "TenDV", datSanh.MaDV);
            ViewBag.MaSanh = new SelectList(db.Sanhs, "MaSanh", "TenSanh", datSanh.MaSanh);
            ViewBag.MaTD = new SelectList(db.Thuc_Don, "MaTD", "SoLuong", datSanh.MaTD);
            return View(datSanh);
        }

        // GET: Admin/DatSanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatSanh datSanh = db.DatSanhs.Find(id);
            if (datSanh == null)
            {
                return HttpNotFound();
            }
            return View(datSanh);
        }

        // POST: Admin/DatSanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatSanh datSanh = db.DatSanhs.Find(id);
            db.DatSanhs.Remove(datSanh);
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
