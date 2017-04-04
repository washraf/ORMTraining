using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Model;
using GenericRepository.Repository;

namespace GenericRepository.CustomRepositories
{
    public interface IStudentRepository:IRepository<Student>
    {
    }
}
