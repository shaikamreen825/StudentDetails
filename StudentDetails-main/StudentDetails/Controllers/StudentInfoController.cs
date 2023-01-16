using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    public class StudentInfoController : Controller
    {
        private tblStudentInfoEntities db = new tblStudentInfoEntities();

        // GET: StudentInfo
        public ActionResult Index()
        {
            var tblStudentInfoes = db.tblStudentInfoes.Include(t => t.Student_Course);
            return View(tblStudentInfoes.ToList());
        }

        // GET: StudentInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblStudentInfo = db.tblStudentInfoes.Find(id);
            if (tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentInfo);
        }

        // GET: StudentInfo/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Student_Course, "Id", "Course");
            return View();
        }

        // POST: StudentInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,studentName,studentMobile,studentAddress,studentDept")] tblStudentInfo tblStudentInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblStudentInfoes.Add(tblStudentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Student_Course, "Id", "Course", tblStudentInfo.StudentId);
            return View(tblStudentInfo);
        }

        // GET: StudentInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblStudentInfo = db.tblStudentInfoes.Find(id);
            if (tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Student_Course, "Id", "Course", tblStudentInfo.StudentId);
            return View(tblStudentInfo);
        }

        // POST: StudentInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,studentName,studentMobile,studentAddress,studentDept")] tblStudentInfo tblStudentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Student_Course, "Id", "Course", tblStudentInfo.StudentId);
            return View(tblStudentInfo);
        }

        // GET: StudentInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblStudentInfo = db.tblStudentInfoes.Find(id);
            if (tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentInfo);
        }

        // POST: StudentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudentInfo tblStudentInfo = db.tblStudentInfoes.Find(id);
            db.tblStudentInfoes.Remove(tblStudentInfo);
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
