using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetAllClasses();
        Class GetClassById(int idClass);
        int AddClass(Class classEntity);
        int UpdateClass(int id, Class classEntity);
        void DeleteClass(int classId);
    }
}
