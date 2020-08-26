using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Seed
{
    public class StudentsSeed
    {
        private List<Student> Students { get; set; }

        public StudentsSeed(AppDbContext appDbContext)
        {
            Students = GetStudents();

            if(!appDbContext.Students.Any())
            {
                foreach(var student in Students)
                {
                    appDbContext.Students.Add(student);
                }

                appDbContext.SaveChanges();
            }
        }

        private List<Student> GetStudents()
        {
             return new List<Student>
            {
                new Student { FirstName = "Ionut", LastName = "Mihai", Age = 15, ClassId = 1 },
                new Student { FirstName = "Mihalea", LastName = "Mirea", Age = 15, ClassId = 1 },

            };
        }
    }
}