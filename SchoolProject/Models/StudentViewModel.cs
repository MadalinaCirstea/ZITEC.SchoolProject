using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SchoolProject.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        public static Expression<Func<Student, StudentViewModel>> Projection
        {
            get
            {
                return p => new StudentViewModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    ClassName = p.Class.Name
                };
            }
        }

        public static StudentViewModel CreateViewModel(Student student)
        {
            return Projection.Compile().Invoke(student);
        }
    }
}