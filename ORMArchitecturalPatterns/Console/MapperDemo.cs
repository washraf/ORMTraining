using System;
using System.Data.SqlClient;
using DataMapper;

namespace Console
{
    public class MapperDemo
    {
        public static void Run()
        {
            char y = 'n';
            StudentMapper mapper = new StudentMapper(new SqlConnection("Data Source=.;Initial Catalog=EMSDb;Integrated Security=True"));

            do
            {
                var student = new Student();
                System.Console.Write("Enter Your Id: ");
                student.Id = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Write("Enter Your Name: ");
                student.Name = System.Console.ReadLine();

                mapper.InsertStudent(student);
                System.Console.Write("Do you want to add More (y)");
                y = System.Console.ReadLine()[0];

            } while (y == 'y');
            var students = mapper.GetAll();

            foreach (var student in students)
            {
                System.Console.WriteLine($" Student {student.Id} Name is {student.Name} ");
            }
            System.Console.ReadLine();
        }
    }
}