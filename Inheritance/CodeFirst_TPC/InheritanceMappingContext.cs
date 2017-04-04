using System.Data.Entity;

namespace CodeFirst_TPC
{
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