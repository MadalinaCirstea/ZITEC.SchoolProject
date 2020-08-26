using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentSubject = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<StudentSubject> StudentSubject { get; set; }

        public void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity
               .HasOne(d => d.Class)
               .WithMany(d => d.Student)
               .HasForeignKey(d => d.ClassId)
               .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}