using Data.Context;
using Data.Models;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ClassRepository()
        {
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _appDbContext.Classes.ToList();
        }
        public Class GetClassById(int classId)
        {
            return _appDbContext.Classes.Find(classId);
        }

        public int AddClass(Class classEntity)

        {
            int result = -1;

            if (classEntity != null)
            {
                _appDbContext.Classes.Add(classEntity);
                _appDbContext.SaveChanges();
                result = classEntity.Id;
            }
            return result;

        }
        public int UpdateClass(int id, Class classEntity)
        {
            int result = -1;

            var classFromDb = _appDbContext.Classes.FirstOrDefault(d => d.Id == id);

            if (classEntity != null)
            {
                classFromDb.Name = classEntity.Name;

                _appDbContext.SaveChanges();
                result = classEntity.Id;
            }
            return result;
        }
        public void DeleteClass(int id)
        {
            Class classEntity = _appDbContext.Classes.Find(id);
            _appDbContext.Classes.Remove(classEntity);
            _appDbContext.SaveChanges();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
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