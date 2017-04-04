using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.CustomRepositories;
using GenericRepository.Model;


namespace GenericRepository.UnitOfWork
{
    public class UnitOfWork:IDisposable
    {
        private CenterEntities _context;
        private IStudentRepository _studentRepository = null;
        public UnitOfWork()
        {
            _context = new CenterEntities();
        }
        public UnitOfWork(CenterEntities context)
        {
            _context = context;
        }
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                    
                }
                return _studentRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
