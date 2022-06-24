using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Repository;
using UpSkillFoundationApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpSkillFoundationApi.Controllers
{
    [Route("api/Departments")]
    [ApiController]
    public class HumanResourcesDepartmentController : ControllerBase
    {   
        private readonly IDepartmentRepository departmentRepository;

        public HumanResourcesDepartmentController(IDepartmentRepository repository)
        {
            departmentRepository = repository;
        }

        // GET: api/<HumanResourcesDepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return departmentRepository.GetDepartments();
        }

        // GET api/<HumanResourcesDepartmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HumanResourcesDepartmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HumanResourcesDepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HumanResourcesDepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
