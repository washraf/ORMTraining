using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Model;

namespace GenericRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork.UnitOfWork uoW = new UnitOfWork.UnitOfWork(new CenterEntities());
            uoW.StudentRepository.Insert(new Student()
            {
                Name = "S1",
                Address = "A1",
                Email = "E1",
                Gender = "M",
                Mobile = "010",
            });
            uoW.StudentRepository.Insert(new Student()
            {
                Name = "S2",
                Address = "A2",
                Email = "E2",
                Gender = "M",
                Mobile = "010",
            });

            uoW.Save();
        }
    }
}
