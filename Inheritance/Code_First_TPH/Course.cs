﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_TPH
{
    public abstract class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public float Price { set; get; }

        public DateTime? StartDate { set; get; }
    }

    public class OnlineCourse : Course
    {
        public bool SelfPaced { get; set; }
    }
    public class LabCourse : Course
    {
        public string Location { get; set; }
    }

    public class InheritanceMappingContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}