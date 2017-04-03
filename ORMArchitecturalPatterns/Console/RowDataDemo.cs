using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RowDataGateway;


namespace Console
{
    public class RowDataDemo
    {
        public static void Run()
        {
            char y = 'n';
            do
            {
                var student = new Student();
                System.Console.Write("Enter Your Id: ");
                student.Id = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Write("Enter Your Name: ");
                student.Name = System.Console.ReadLine();

                StudentRowGateway gateway = new StudentRowGateway(student);
                gateway.InsertStudent();
                System.Console.Write("Do you want to add More (y)");
                y = System.Console.ReadLine()[0];

            } while (y == 'y');
            var students = StudentRowGateway.GetAll();

            foreach (var student in students)
            {
                System.Console.WriteLine($" Student {student.Id} Name is {student.Name} ");
            }
            System.Console.ReadLine();
        }
    }
}
