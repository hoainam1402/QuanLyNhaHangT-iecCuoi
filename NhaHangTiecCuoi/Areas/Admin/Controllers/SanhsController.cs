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
    public class SanhsController : Controller
    {
        private QLNHTiecCuoiEntities db = new QLNHTiecCuoiEntities();

        // GET: Admin/Sanhs
        public ActionResult Index()
        {
            return View(db.Sanhs.ToList());
        }

        // GET: Admin/Sanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanh sanh = db.Sanhs.Find(id);
            if (sanh == null)
            {
                return HttpNotFound();
            }
            return View(sanh);
        }

        // GET: Admin/Sanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanh,TenSanh,Gia,Img")] Sanh sanh)
        {
            if (ModelState.IsValid)
            {
                db.Sanhs.Add(sanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanh);
        }

        // GET: Admin/Sanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanh sanh = db.Sanhs.Find(id);
            if (sanh == null)
            {
                return HttpNotFound();
            }
            return View(sanh);
        }

        // POST: Admin/Sanhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanh,TenSanh,Gia,Img")] Sanh sanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanh);
        }

        // GET: Admin/Sanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanh sanh = db.Sanhs.Find(id);
            if (sanh == null)
            {
                return HttpNotFound();
            }
            return View(sanh);
        }

        // POST: Admin/Sanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanh sanh = db.Sanhs.Find(id);
            db.Sanhs.Remove(sanh);
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
