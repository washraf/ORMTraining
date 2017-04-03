using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper.Context;
using Mapper.Sets;

namespace Application
{
    public class Context : ContextBase
    {
        public TableSet<Student> Students;
        public TableSet<Course> Courses;
        public Context(string conString) : base(conString)
        {
            Students = new TableSet<Student>(_connection);
            Courses = new TableSet<Course>(_connection);
        }
    }
}
