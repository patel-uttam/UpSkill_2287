using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationML1.API.Models;

namespace UpSkillFoundationML1.API.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(int id);
        public bool UpdateStudent(int id,Student  student);
        public bool DeleteStudent(int id);
        public bool AddStudent(Student student);
    }
}
