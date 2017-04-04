using System.Data.Entity;

namespace Code_First_TPH
{
    public class InheritanceMappingContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}