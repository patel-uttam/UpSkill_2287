using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationML1.API.Models;

namespace UpSkillFoundationML1.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        List<Student> students = new List<Student>();

        public StudentRepository()
        {
            var newStudents = new List<Student>()
            {

                new Student {StudentId = 1, StudentName="Gaddu", EducationStream="Arts", Standard=11},
                new Student {StudentId=2, StudentName="Kaleen_Bhaiya", EducationStream="Commerce",Standard=11},
                new Student { StudentId=3, StudentName= "Gaitonde", EducationStream="Commerce",Standard=12},
                new Student { StudentId=4, StudentName="Guddu", EducationStream="Arts", Standard=11},
                new Student { StudentId=5, StudentName="Munna", EducationStream="Arts", Standard=11},
                new Student { StudentId=6, StudentName="babblu", EducationStream="Science", Standard=12},
                new Student { StudentId=7, StudentName="Parpedicular", EducationStream="Commerce", Standard=12},
                new Student { StudentId=8, StudentName="Definite", EducationStream="Science", Standard=12},
                new Student { StudentId=9, StudentName= "Compounder", EducationStream= "Science", Standard=11}
            };

            students.AddRange(newStudents);
        }

        public bool AddStudent(Student student)
        {
            try
            {
                students.Add(student);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            students.Remove(students.Find(s => s.StudentId == id));
            
            if(students.Find(s => s.StudentId == id) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Student GetStudent(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return students.ToList();
        }

        public bool UpdateStudent(int id,Student student)
        {
            try
            {
                int index = students.FindIndex(0,s=>s.StudentId == id);
                students[index].StudentName = student.StudentName;
                students[index].EducationStream = student.EducationStream;
                students[index].Standard = student.Standard;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
