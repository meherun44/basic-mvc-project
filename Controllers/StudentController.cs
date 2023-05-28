using BasicMVCProject.Data;
using BasicMVCProject.Models;
using BasicMVCProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMVCProject.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentContext context;
        private readonly IStudentRepository repository;

        public StudentController(StudentContext _context, IStudentRepository _repository)
        {
            context = _context;
            repository = _repository;
        }


        public IActionResult defaultMessage(string name, string department,int id)
        {
            dynamic model = new ExpandoObject();
            model.Id = id;
            model.Name = name;
            model.Discipline = department;

            ViewBag.Data = model;
            return View();
        }

        public IActionResult welcome(string name, int counter) {
            ViewData["name"] = name;
            ViewData["counter"] = counter;

            return View();
        }

        public IActionResult GetStudentById(int id)
        {
            if (id <= 0) {
                return NotFound();
            }
            var student = repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        public ViewResult AddStudent() {
            return View();
        }

        [HttpPost]
        public ViewResult AddStudent(Student student) {
            int id = 0;
            if (ModelState.IsValid)
            {
                id = repository.AddStudent(student);
                ViewBag.isSuccess = true;
                return View("Success");
            }
            
            ViewBag.Id = id;
            return View();

        }

        public IActionResult GetAllStudent() {

            var students = repository.GetAllStudent();
            return View(students);
        }

        
    }
}
