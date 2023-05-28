using BasicMVCProject.Data;
using BasicMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMVCProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext context = null;

        public StudentRepository(StudentContext _context) {
            context = _context;
        }
        public int AddStudent(Student model) {
            var student = new Student()
            {
                Name = model.Name,
                Discipline = model.Discipline,
                BirthDate = model.BirthDate,
                Address = model.Address

            };

            context.Students.Add(student);
            context.SaveChanges();

            return student.Id;
        }

        public Student GetStudentById(int id) {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            return student;
        }

        public List<Student> GetAllStudent() {

            var students = new List<Student>();
            var data = context.Students.ToList();
            if (data?.Any() == true) {
                foreach (var d in data) {
                    var student = new Student()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        BirthDate = d.BirthDate,
                        Discipline = d.Discipline,
                        Address = d.Address
                    };

                    students.Add(student);
                }
            }
            return data;
        }
    }
}
