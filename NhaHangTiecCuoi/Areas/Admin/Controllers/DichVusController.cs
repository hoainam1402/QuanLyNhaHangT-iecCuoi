﻿using System;
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
    public class DichVusController : Controller
    {
        private QLNHTiecCuoiEntities db = new QLNHTiecCuoiEntities();

        // GET: Admin/DichVus
        public ActionResult Index()
        {
            var dichVus = db.DichVus.Include(d => d.LoaiDichVu);
            return View(dichVus.ToList());
        }

        // GET: Admin/DichVus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: Admin/DichVus/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDV = new SelectList(db.LoaiDichVus, "MaLoai", "TenLoai");
            return View();
        }

        // POST: Admin/DichVus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDV,TenDV,DonGia,MaLoaiDV,Img")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.DichVus.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDV = new SelectList(db.LoaiDichVus, "MaLoai", "TenLoai", dichVu.MaLoaiDV);
            return View(dichVu);
        }

        // GET: Admin/DichVus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDV = new SelectList(db.LoaiDichVus, "MaLoai", "TenLoai", dichVu.MaLoaiDV);
            return View(dichVu);
        }

        // POST: Admin/DichVus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDV,TenDV,DonGia,MaLoaiDV,Img")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDV = new SelectList(db.LoaiDichVus, "MaLoai", "TenLoai", dichVu.MaLoaiDV);
            return View(dichVu);
        }

        // GET: Admin/DichVus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: Admin/DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DichVu dichVu = db.DichVus.Find(id);
            db.DichVus.Remove(dichVu);
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
