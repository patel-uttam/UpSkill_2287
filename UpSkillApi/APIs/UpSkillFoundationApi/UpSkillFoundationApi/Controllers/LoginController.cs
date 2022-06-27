using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UpSkillFoundationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            try
            {
                if (login.UserName == "Admin" && login.Password == "Pass")
                {
                    return Ok(new
                    {
                        message = "user authentication done",
                        status = StatusCodes.Status200OK
                    });
                }
                else
                {
                    return Unauthorized(new
                    {
                        message = "user not authorize",
                        status = StatusCodes.Status401Unauthorized
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    message = "error in loign",
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
