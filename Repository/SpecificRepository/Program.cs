using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecificRepository.Model;
using SpecificRepository.Repositories;

namespace SpecificRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository studentRepository =
               new StudentRepository(new CenterEntities());
            var students = studentRepository.GetStudents().ToList();
            foreach (var stu in students)
            {
                Console.Write(stu.Student_ID);
                Console.Write("\t");
                Console.Write(stu.Name);
                Console.WriteLine();
            }
        }
    }
}
