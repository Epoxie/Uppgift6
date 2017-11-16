using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RelationalDatabase.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View(Common.Common.SchoolRepository.GetAllCourses());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subject")] Course course)
        {
            if (ModelState.IsValid)
            {
                Common.Common.SchoolRepository.AddCourse(course);
                return RedirectToAction("Index");
            }

            return View(course); // return if modelstate is invalid
        }

        public ActionResult Edit(int id)
        {
            return View(Common.Common.SchoolRepository.GetCourseDetails(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CID, Subject")] Course course)
        {
            if (ModelState.IsValid)
            {
                Common.Common.SchoolRepository.EditCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int id)
        {
            return View(Common.Common.SchoolRepository.GetCourseDetails(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Common.Common.SchoolRepository.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}