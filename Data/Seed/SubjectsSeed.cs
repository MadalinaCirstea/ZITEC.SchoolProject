using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Seed
{
    public class SubjectsSeed
    {
        private List<Subject> Subjects { get; set; }

        public SubjectsSeed(AppDbContext appDbContext)
        {
            Subjects = GetSubjects();

            foreach (var subjectsToAdd in Subjects)
            {
                if (!appDbContext.Subjects.Any(d => d.Name == subjectsToAdd.Name))
                {
                    appDbContext.Subjects.Add(subjectsToAdd);
                }
            }

            appDbContext.SaveChanges();
        }

        private List<Subject> GetSubjects()
        {
            return new List<Subject>
            {
                new Subject { Name = "Romanian" },
                new Subject { Name = "Maths" },
                new Subject { Name = "Physics" },
                new Subject { Name = "Chemistry" },
                new Subject { Name = "Sports" }
            };
        }
    }
}