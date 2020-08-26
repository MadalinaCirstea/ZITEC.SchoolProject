using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories.Interfaces;
using Data.Models;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public ActionResult GetClasses()
        {
            var classEntities = _classRepository.GetAllClasses();

            return View(classEntities);
        }

        public ActionResult AddClass()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Class Failed";
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddClass(ClassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newClass = new Class()
                {
                    Name = model.Name
                };
                int result = _classRepository.AddClass(newClass);
                if (result > 0)
                {
                    return RedirectToAction("GetClasses", "Class");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("AdClass", "Class");
                }
            }
            return View();
        }

        public PartialViewResult EditClass(int id)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Employee Failed";
            }
            var viewModel = ClassViewModel.CreateViewModel(_classRepository.GetClassById(id));

            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult EditClass(int id, ClassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newClass = new Class()
                {
                    Name = model.Name
                };
                int result = _classRepository.UpdateClass(id, newClass);
                if (result > 0)
                {
                    return RedirectToAction("GetClasses", "Class");
                }
                else
                {

                    return RedirectToAction("GetClasses", "Class");
                }
            }
            return PartialView();
        }


        public ActionResult DeleteClass(int classId)
        {
            Class model = _classRepository.GetClassById(classId);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteClass(Class model)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Employee Failed";
            }
            _classRepository.DeleteClass(model.Id);
            return RedirectToAction("GetClasses", "Class");
        }

    }
}