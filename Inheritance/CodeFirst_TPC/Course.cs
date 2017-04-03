using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OnlineCourse>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("OnlineCourse");
            });

            modelBuilder.Entity<LabCourse>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("LabCourse");
            });
        }
    }
}
