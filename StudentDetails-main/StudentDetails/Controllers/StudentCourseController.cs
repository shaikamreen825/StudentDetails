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
    public class StudentCourseController : Controller
    {
        private tblStudentInfoEntities db = new tblStudentInfoEntities();

        // GET: StudentCourse
        public ActionResult Index()
        {
            var student_Course = db.Student_Course.Include(s => s.tblStudentInfo);
            return View(student_Course.ToList());
        }

        // GET: StudentCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // GET: StudentCourse/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.tblStudentInfoes, "StudentId", "studentName");
            return View();
        }

        // POST: StudentCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Course")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                db.Student_Course.Add(student_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.tblStudentInfoes, "StudentId", "studentName", student_Course.Id);
            return View(student_Course);
        }

        // GET: StudentCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.tblStudentInfoes, "StudentId", "studentName", student_Course.Id);
            return View(student_Course);
        }

        // POST: StudentCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Course")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.tblStudentInfoes, "StudentId", "studentName", student_Course.Id);
            return View(student_Course);
        }

        // GET: StudentCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // POST: StudentCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Course student_Course = db.Student_Course.Find(id);
            db.Student_Course.Remove(student_Course);
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
