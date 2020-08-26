using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public partial class Subject
    {
        public Subject()
        {
            StudentSubject = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<StudentSubject> StudentSubject { get; set; }

        public void ConfigureEntity(ModelBuilder modelBuilder)
        {
        }
    }
}