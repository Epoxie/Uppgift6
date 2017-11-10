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

        public void AddStudent(Student student)
        {
            SchoolContext.Students.Add(student);
            SchoolContext.SaveChanges();
        }

        public void Edit(Student student)
        {
            SchoolContext.Entry(student).State = EntityState.Modified;
            SchoolContext.SaveChanges();
        }

        public void Delete(int id)
        {
            SchoolContext.Students.Remove(GetStudentDetails(id));
            SchoolContext.SaveChanges();
        }
    }
}