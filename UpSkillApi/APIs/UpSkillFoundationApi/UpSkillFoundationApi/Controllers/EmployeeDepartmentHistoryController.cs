using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;
using UpSkillFoundationApi.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpSkillFoundationApi.Controllers
{
    [Route("api/DeptEmpHistory")]
    [ApiController]
    public class EmployeeDepartmentHistoryController : ControllerBase
    {
        private readonly IEmployeeDepartmentHistoryRepository repository;
        public EmployeeDepartmentHistoryController(IEmployeeDepartmentHistoryRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/<EmployeeDepartmentHistoryController>
        [HttpGet]
        public IEnumerable<EmployeeDepartmentHistory> Get()
        {
            return repository.GetEmployeeDepartmentHistory();
        }

        // GET api/<EmployeeDepartmentHistoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeDepartmentHistoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeDepartmentHistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE api/<EmployeeDepartmentHistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
