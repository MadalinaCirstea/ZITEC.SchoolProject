using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudentsByClass(int idClass);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int idStudent);
        int AddStudent(Student student);
        int UpdateStudent(Student student);
        void DeleteStudent(int studentId);
    }
}
