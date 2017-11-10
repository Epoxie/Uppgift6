using MVC_RelationalDatabase.DataAccess;
using MVC_RelationalDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_RelationalDatabase.Repositories
{
    public class SchoolRepository
    {
        SchoolContext SchoolContext = new SchoolContext();

        public IEnumerable<Student> GetAllStudents()
        {
            return SchoolContext.Students.Include(s => s.Course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return SchoolContext.Courses;
        }

        public Student GetStudentDetails(int id)
        {
            return SchoolContext.Students.Include(s => s.Course).FirstOrDefault(i => i.SID == id);
        }

        public Course GetCourseDetails(int id)
        {
            return SchoolContext.Courses.FirstOrDefault(i => i.CID == id);
        }

        public void AddStudent(Student student)
        {
            SchoolContext.Students.Add(student);
            SchoolContext.SaveChanges();
        }

        public void AddCourse(Course course)
        {
            SchoolContext.Courses.Add(course);
            SchoolContext.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            SchoolContext.Entry(student).State = EntityState.Modified;
            SchoolContext.SaveChanges();
        }

        public void EditCourse(Course course)
        {
            SchoolContext.Entry(course).State = EntityState.Modified;
            SchoolContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            SchoolContext.Students.Remove(GetStudentDetails(id));
            SchoolContext.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            SchoolContext.Courses.Remove(GetCourseDetails(id));
            SchoolContext.SaveChanges();
        }
    }
}