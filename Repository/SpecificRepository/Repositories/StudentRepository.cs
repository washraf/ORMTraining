using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SpecificRepository.Model;

namespace SpecificRepository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private CenterEntities context;
        public StudentRepository(CenterEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }
        public Student GetStudentByID(int id)
        {
            return context.Students.Find(id);
        }
        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }
        public void DeleteStudent(int studentID)
        {
            Student student = context.Students.Find(studentID);
            context.Students.Remove(student);
        }
        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Student> GetByFilter(Expression<Func<Student,bool>> filter)
        {
            return context.Students.Where(filter);
        }
    }
}
