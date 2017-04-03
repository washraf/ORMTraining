using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context("Data Source =.; Initial Catalog = Center; Integrated Security = True");

            IEnumerable<Student> students = context.Students.GetAll();
            foreach (var s in students)
            {
                System.Console.Write(s.Student_ID);
                System.Console.Write("\t");
                System.Console.Write(s.Name);
                System.Console.WriteLine();
            }

            context.Students.Add(new Student()
            {
                // Student_ID = 456,
                Name = "ali",
                EMail = "a",
                Address = "123",
                Mobile = "123",
                Gender = "M"
            });
            var ss = students.ToList()[0];
            ss.Name = "Hamada";
            context.Students.Update(ss);


            List<Course> course = context.Courses.Find(x => x.Course_ID > 1).ToList();
            foreach (var s in course)
            {
                System.Console.Write(s.Course_ID);
                System.Console.Write("\t");
                System.Console.Write(s.CourseName);
                System.Console.WriteLine();
                System.Console.WriteLine(s.Intakes.First().course.Course_ID);
            }

            #region --Yield Demo--

            //IEnumerable<string> numbers = GetNumbers();

            //foreach (string item in numbers)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion


            #region --reflection Demo--
            //    Student std = new Student();

            //var xxx = std.GetType().GetProperties(BindingFlags.Public|
            //    BindingFlags.NonPublic | BindingFlags.Instance);
            //foreach (var item in xxx)
            //{
            //    item.SetValue(std, Convert.ChangeType("1", item.PropertyType));
            //    Console.WriteLine(item.Name);
            //    var attrs = item.CustomAttributes;
            //    foreach (var i in attrs)
            //    {
            //        Console.WriteLine("\t - "+i);
            //    }
            //}
            //Console.WriteLine($"{std.Name} \t {std.Address}");
            #endregion
        }

        //private static IEnumerable<string> GetNumbers()
        //{
        //    for (int i = 0; i < 150; i++)
        //    {
        //        yield return i.ToString();
        //    }
        //}
    }
}
