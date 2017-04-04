using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_TPC
{
    public abstract class Course
    {
        [Key]
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public float Price { set; get; }
    }
}
