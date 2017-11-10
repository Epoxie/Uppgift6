using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_RelationalDatabase.Models
{
    public class Course
    {
        [Key]
        public int CID { get; set; }
        public string Subject { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}