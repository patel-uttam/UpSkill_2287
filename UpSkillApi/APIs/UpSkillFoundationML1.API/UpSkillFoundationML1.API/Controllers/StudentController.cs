using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationML1.API.Models;
using UpSkillFoundationML1.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpSkillFoundationML1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository repository)
        {
            studentRepository = repository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentRepository.GetStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return studentRepository.GetStudent(id);
        }

        // POST api/<StudentController>
        [HttpPost("NewStudent")]
        public bool Post([FromBody] Student student)
        {
            return studentRepository.AddStudent(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("UpdateStudent/{id}")]
        public bool Put(int id,[FromBody] Student student)
        {
            return studentRepository.UpdateStudent(id,student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("DeleteStudent/{id}")]
        public bool Delete(int id)
        {
            return studentRepository.DeleteStudent(id);
        }
    }
}
