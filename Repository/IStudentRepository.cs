using BasicMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMVCProject.Repository
{
    public interface IStudentRepository
    {
        public int AddStudent(Student model);
        public Student GetStudentById(int id);
        public List<Student> GetAllStudent();
    }
}
