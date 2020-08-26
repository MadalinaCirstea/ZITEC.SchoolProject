using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects();
        Subject GetSubjectById(int idSubject);
        int AddSubject(Subject subject);
        int UpdateSubject(Subject subject);
        void DeleteSubject(int subjectId);
    }
}
