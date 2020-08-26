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
    public class StudentRepository :IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Student> GetAllStudentsByClass(int idClass)
        {
            return _appDbContext.Students.Where(d=>d.ClassId == idClass).ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _appDbContext.Students.Include(d=>d.Class).ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return _appDbContext.Students
                .Include(d=>d.Class)
                .FirstOrDefault(d=>d.Id == studentId);
        }

        public int AddStudent(Student student)
        {
            int result = -1;

            if (student != null)
            {
                _appDbContext.Students.Add(student);
                _appDbContext.SaveChanges();
                result = student.Id;
            }
            return result;

        }
        public int UpdateStudent(Student student)
        {
            int result = -1;

            if (student != null)
            {
                _appDbContext.Entry(student).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                result = student.Id;
            }
            return result;
        }
        public void DeleteStudent(int id)
        {
            Student student = _appDbContext.Students.Find(id);
            _appDbContext.Students.Remove(student);
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