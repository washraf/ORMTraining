using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveRecord;

namespace Console
{
    class ActiveRecordDemo
    {
        public static void Run()
        {
            char y = 'n';
            do
            {
                var student = new StudentActiveRecord();
                System.Console.Write("Enter Your Id: ");
                student.Id = Convert.ToInt32(System.Console.ReadLine());
                System.Console.Write("Enter Your Name: ");
                student.Name = System.Console.ReadLine();

                student.InsertStudent();
                System.Console.Write("Do you want to add More (y)");
                y = System.Console.ReadLine()[0];

            } while (y == 'y');
            var students = StudentActiveRecord.GetAll();

            foreach (var student in students)
            {
                System.Console.WriteLine($" Student {student.Id} Name is {student.Name} ");
            }
            System.Console.ReadLine();
        }
    }
}
