using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Repository
{
    public class Authentication : IAuthentication
    {
        public Task<IActionResult> LoggingAdmin(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
