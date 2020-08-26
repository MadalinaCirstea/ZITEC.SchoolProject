using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class StudentSubject
    {
        public StudentSubject()
        {
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }

        public void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity
               .HasOne(d => d.Student)
               .WithMany(d => d.StudentSubject)
               .HasForeignKey(d => d.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

                entity
               .HasOne(d => d.Subject)
               .WithMany(d => d.StudentSubject)
               .HasForeignKey(d => d.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}