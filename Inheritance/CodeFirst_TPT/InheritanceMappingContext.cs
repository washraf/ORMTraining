using System.Data.Entity;

namespace CodeFirst_TPT
{
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