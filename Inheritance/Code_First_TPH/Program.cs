using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_TPH
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new InheritanceMappingContext())
            {
                Console.WriteLine("All courses:");
                foreach (var course in context.Courses)
                {
                    Console.WriteLine("{0}\t{1}", course.CourseId, course.CourseName);
                }

                Console.WriteLine("Online only: ");
                foreach (var course in context.Courses.OfType<OnlineCourse>())
                {
                    Console.WriteLine("{0}\t{1}\t{2}", course.CourseId, course.CourseName, course.SelfPaced);
                }

                Console.WriteLine("Lab only: ");
                foreach (var course in context.Courses.OfType<LabCourse>())
                {
                    Console.WriteLine("{0}\t{1}\t{2}", course.CourseId, course.CourseName, course.Location);
                }
                OnlineCourse online = new OnlineCourse()
                {
                    CourseName = "Added In time " + DateTime.Now,
                    SelfPaced = true,
                    Price = 123
                };

                LabCourse lab = new LabCourse()
                {
                    CourseName = "Added In time " + DateTime.Now,
                    Location = "Home Center",
                    Price = 123
                };
                context.Courses.Add(online);
                context.Courses.Add(lab);

                context.SaveChanges();
            }
        }
    }
}
