using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper.Attibutes;

namespace Application
{
    public class Course
    {
        [AutoId]
        [EntityKey]
        public int Course_ID { private set; get; }
        public string CourseName { set; get; }
        public string CourseDescription { set; get; }
        public string CourseContents { set; get; }
        public int CourseDuration { set; get; }

        public virtual IEnumerable<Intake> Intakes { get; set; }
    }
}
