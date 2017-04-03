using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDataGateway;

namespace Console
{
    class TableDataDemo
    {
        public static void Run()
        {
            char y = 'n';
            var gateway = new StudentTableGateway();

            do
            {
                System.Console.Write("Enter Your Name: ");
                gateway.Insert(System.Console.ReadLine());
                
                System.Console.Write("Do you want to add More (y)");
                y = System.Console.ReadLine()[0];

            } while (y == 'y');
            var students = gateway.FindAll();

            for (int i = 0; i < students.Rows.Count; i++)
            {
                System.Console.WriteLine($" Student {students.Rows[i][0]} Name is {students.Rows[i][1]} ");
            }
            System.Console.ReadLine();
        }
    }
}
