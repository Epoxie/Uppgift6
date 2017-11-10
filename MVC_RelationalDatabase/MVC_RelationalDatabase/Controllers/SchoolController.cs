using MVC_RelationalDatabase.Models;
using MVC_RelationalDatabase.Repositories;
using MVC_RelationalDatabase.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            return View(Common.Common.SchoolRepository.GetAllStudents());
        }

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(Common.Common.SchoolRepository.GetAllCourses(), "CID", "Subject");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, CourseId")] Student student)
        {
            if (ModelState.IsValid)
            {
                Common.Common.SchoolRepository.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student); // return if modelstate is invalid
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CourseId = new SelectList(Common.Common.SchoolRepository.GetAllCourses(), "CID", "Subject");
            return View(Common.Common.SchoolRepository.GetStudentDetails(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SID, Name, CourseId")] Student student)
        {
            if (ModelState.IsValid)
            {
                Common.Common.SchoolRepository.EditStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.CourseId = new SelectList(Common.Common.SchoolRepository.GetAllCourses(), "CID", "Subject");
            return View(Common.Common.SchoolRepository.GetStudentDetails(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Common.Common.SchoolRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}