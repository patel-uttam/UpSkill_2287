 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models.queryParams;
using UpSkillFoundationApi.Models.Response;
using UpSkillFoundationApi.Repository;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using UpSkillFoundationApi.Models;
using Microsoft.AspNetCore.JsonPatch;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpSkillFoundationApi.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class HumanResourcesEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employee;

        public HumanResourcesEmployeeController(IEmployeeRepository employeeRepository)
        {
            employee = employeeRepository;
        }

        // GET: api/<HumanResourcesEmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] EmployeeQueryParam  queryparam)
        {
            try
            {
                var query = new EmployeeQueryParam(queryparam.PageNumber, queryparam.ItemPerPage, queryparam.JobTitle, queryparam.OrganizationLevel, queryparam.StartVacation, queryparam.EndVacation);
                
                var filterEmployee = employee.GetFilterEmployees(queryparam.JobTitle,queryparam.OrganizationLevel,queryparam.StartVacation,queryparam.EndVacation);
                
                if(filterEmployee.Count() < ((query.PageNumber-1)*query.ItemPerPage))
                {
                    if(filterEmployee.Count() > query.ItemPerPage)
                    {
                        query.PageNumber = (int)(filterEmployee.Count() / query.ItemPerPage);
                    }
                    else
                    {
                        query.PageNumber = 1;
                    }
                }
                var finalEmployee = filterEmployee.Skip((query.PageNumber - 1) * query.ItemPerPage).Take(query.ItemPerPage);
                
                var checkfornextpage = filterEmployee.Skip(query.PageNumber * query.ItemPerPage).Take(query.ItemPerPage);

                var jobTitle = employee.GetDistinctjobTitle().ToList();

                var organizationLevel = employee.GetDistinctOrganizationLevel().ToList();

                return Ok(new EmployeeResponse<List<Employee>>(finalEmployee.ToList(), query.PageNumber, query.ItemPerPage, query.PageNumber == 1 ? false : true , checkfornextpage.Count() > 0 ? true : false,jobTitle,organizationLevel));
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        // GET api/<HumanResourcesEmployeeController>/5
        [HttpGet]
        [Route("EmpByDept/{Deptid}")]
        public IEnumerable<Employee> Get(int Deptid)
        {
            return employee.GetEmpDeptHistory(Deptid); 
        }

        // GET api/<HumanResourcesEmployeeController>/jobtitle/organizationlevel/startvacation/endvacation/startsickness/endsickness
        [HttpGet()]
        [Route("filter/{jobtitle}/{organizationlevel}/{startvacation}/{endvacation}/{startsick}/{endsick}")]
        [Route("filter/{organizationlevel}/{startvacation}/{endvacation}/{startsick}/{endsick}")]
        [Route("filter/{startvacation}/{endvacation}/{startsick}/{endsick}")]
        public IEnumerable<Employee> Get(List<string> jobtitle, string organizationlevel, string startvacation, string endvacation, string startsick, string endsick)
        {
            var employeeResult = employee.GetFilterEmployees(jobtitle, organizationlevel, startvacation, endvacation);
            return employeeResult.OrderBy(o => o.JobTitle).ThenBy(o => o.VacationHours).ThenBy(o => o.SickLeaveHours);
        }

        // POST api/<HumanResourcesEmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            /*            if(ModelState.IsValid)
                        {
                            return "validation true";
                        }
                        else
                        {
                            return "validation false";
                        }*/
            Console.WriteLine(emp.Rowguid);
            return null;
        }

        // PUT api/<HumanResourcesEmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //PATCH api/<EmployeeDepartmentHistoryController>
        [HttpPatch]
        [Route("patchUpdate/{BusId}")]
        public IActionResult patch(int BusId , [FromBody] JsonPatchDocument<Employee> jsonPatch)
        {
            if(jsonPatch != null)
            {
                var data = employee.GetEmployee(BusId); 

                jsonPatch.ApplyTo(data,ModelState);

                if (ModelState.IsValid)
                {
                    if(employee.UpdateEmployee(data))
                    {
                        return Ok(
                            new 
                            {
                            msg = "Patch Update Successful",
                            data = jsonPatch
                            });
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
            }
            throw new NotImplementedException();
        }

        // DELETE api/<HumanResourcesEmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
