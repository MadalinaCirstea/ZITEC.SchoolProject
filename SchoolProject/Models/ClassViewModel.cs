using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SchoolProject.Models
{
    public class ClassViewModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public static Expression<Func<Class, ClassViewModel>> Projection
        {
            get
            {
                return p => new ClassViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                };
            }
        }

        public static ClassViewModel CreateViewModel(Class classModel)
        {
            return Projection.Compile().Invoke(classModel);
        }
    }
}