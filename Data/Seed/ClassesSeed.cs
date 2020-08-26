using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Seed
{
    public class ClassesSeed
    {
        private List<Class> Classes { get; set; }

        public ClassesSeed(AppDbContext appDbContext)
        {
            Classes = GetClasses();

            foreach(var classToAdd in Classes)
            {
                if(!appDbContext.Classes.Any(d=>d.Name == classToAdd.Name))
                {
                    appDbContext.Classes.Add(classToAdd);
                }
            }

            appDbContext.SaveChanges();
        }

        private List<Class> GetClasses()
        {
            return new List<Class>
            {
                new Class { Name = "9A" },
                new Class { Name = "9B" },
                new Class { Name = "10A" },
                new Class { Name = "10B" },
                new Class { Name = "11A" },
                new Class { Name = "11B" },
                new Class { Name = "12A" },
                new Class { Name = "12B" },
            };
        }
    }
}