using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UpSkillFoundationApi.Authentication;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        public AuthenticationController(UserManager<Users> user , RoleManager<IdentityRole> role , IConfiguration _configuration)
        {
            userManager = user;
            roleManager = role;
            configuration = _configuration;
        }

        // Sign-up admin
        [HttpPost]
        [Route("Employee-Admin")]
        public async Task<IActionResult> AdminRegistration([FromBody] Registration registration)
        {
            var isUserExist = await userManager.FindByNameAsync(registration.UserName);
            if(isUserExist == null && registration.Password == registration.ConfirmPassword)
            {
                Users user = new Users();

                user.UserName = registration.UserName;

                var usercreation = await userManager.CreateAsync(user, registration.Password);

                if (!usercreation.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "usre registration not completed successfully" });
                }

                if (!await roleManager.RoleExistsAsync(Roles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                }
                if (await roleManager.RoleExistsAsync(Roles.Admin))
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                }

                if (!await roleManager.RoleExistsAsync(Roles.Employee))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Employee));
                }
                if (await roleManager.RoleExistsAsync(Roles.Employee))
                {
                    await userManager.AddToRoleAsync(user, Roles.Employee);
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    title = "Registration complete"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status302Found, new { msg = "user already Exist" });
            }
        }


        // Sign-up employee
        [HttpPost]
        [Route("Employee-Admin")]
        public async Task<IActionResult> EmployeeRegistration([FromBody] Registration registration)
        {
            var isUserExist = await userManager.FindByNameAsync(registration.UserName);
            if (isUserExist == null && registration.Password == registration.ConfirmPassword)
            {
                Users user = new Users();

                user.UserName = registration.UserName;

                var usercreation = await userManager.CreateAsync(user, registration.Password);

                if (!usercreation.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "usre registration not completed successfully" });
                }

                if (!await roleManager.RoleExistsAsync(Roles.Employee))
                {
                    await roleManager.CreateAsync(new IdentityRole(Roles.Employee));
                }
                if (await roleManager.RoleExistsAsync(Roles.Employee))
                {
                    await userManager.AddToRoleAsync(user, Roles.Employee);
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    title = "Registration complete"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status302Found, new { msg = "user already Exist" });
            }
        }


        // usre Login
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> userLogin([FromBody] LoginCredential login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);

            if(user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var roles = await userManager.GetRolesAsync(user);

                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("name", user.UserName));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                foreach(var role in roles)
                {
                    claims.Add(new Claim("roles",role));
                }

                var authsign = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secret"]));

                var _token = new JwtSecurityToken(issuer: configuration["JWT:Validissuer"], audience: configuration["JWT:ValidAudience"], claims: claims, signingCredentials: new SigningCredentials(authsign, SecurityAlgorithms.HmacSha256));

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(_token),
                        message = "User Authorized"
                    }
                );
            }

            return Ok();
        }

    }
}
