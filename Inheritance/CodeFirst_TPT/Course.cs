using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_TPT
{
    public abstract class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public float Price { set; get; }
    }

    [Table("OnlineCourse")]
    public class OnlineCourse : Course
    {
        public bool SelfPaced { get; set; }
    }

    [Table("LabCourse")]
    public class LabCourse : Course
    {
        public string Location { get; set; }
    }

    public class InheritanceMappingContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OnlineCourse>().ToTable("OnlineCourse");
            //modelBuilder.Entity<LabCourse>().ToTable("LabCourse");
        }
    }
}
