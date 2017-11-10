using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class Teacher
    {
        [Key]
        public int TID { get; set; }
        public string Name { get; set; }

        public ICollection<Course> Course { get; set; }
    }
}