using MVC_RelationalDatabase.Models;
using MVC_RelationalDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Controllers
{
    public class SchoolController : Controller
    {
        SchoolRepository SchoolRepository = new SchoolRepository();

        // GET: School
        public ActionResult Index()
        {
            return View(SchoolRepository.GetAllStudents());
        }

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(SchoolRepository.GetAllCourses(), "CID", "Subject");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, CourseId")] Student student)
        {
            if (ModelState.IsValid)
            {
                SchoolRepository.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student); // return if modelstate is invalid
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CourseId = new SelectList(SchoolRepository.GetAllCourses(), "CID", "Subject");
            return View(SchoolRepository.GetStudentDetails(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SID, Name, CourseId")] Student student)
        {
            if (ModelState.IsValid)
            {
                SchoolRepository.Edit(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            ViewBag.CourseId = new SelectList(SchoolRepository.GetAllCourses(), "CID", "Subject");
            return View(SchoolRepository.GetStudentDetails(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}