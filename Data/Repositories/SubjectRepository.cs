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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public SubjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _appDbContext.Subjects.ToList();
        }
        public Subject GetSubjectById(int subjectId)
        {
            return _appDbContext.Subjects.Find(subjectId);
        }

        public int AddSubject(Subject subject)

        {
            int result = -1;

            if (subject != null)
            {
                _appDbContext.Subjects.Add(subject);
                _appDbContext.SaveChanges();
                result = subject.Id;
            }
            return result;

        }
        public int UpdateSubject(Subject subject)
        {
            int result = -1;

            if (subject != null)
            {
                _appDbContext.Entry(subject).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                result = subject.Id;
            }
            return result;
        }
        public void DeleteSubject(int id)
        {
            Subject subject = _appDbContext.Subjects.Find(id);
            _appDbContext.Subjects.Remove(subject);
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