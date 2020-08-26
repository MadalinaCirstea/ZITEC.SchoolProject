using Data.Repositories.Interfaces;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ActionResult GetStudents()
        {
            var students = _studentRepository.GetAllStudents();

            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();

            foreach(var student in students)
            {
                studentViewModels.Add(StudentViewModel.CreateViewModel(student));
            }

            return View(studentViewModels);
        }

        [HttpGet, Route("{id}")]
        public ActionResult GetAllStudentsByClass(int id)
        {
            var students = _studentRepository.GetAllStudentsByClass(id);
            return View(students);
        }
    }
}