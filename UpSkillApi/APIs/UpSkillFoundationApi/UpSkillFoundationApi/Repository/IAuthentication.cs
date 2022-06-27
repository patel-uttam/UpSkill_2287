using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Repository
{
    public interface IAuthentication
    {
        public Task<IActionResult> LoggingAdmin(LoginCredential login);
    }
}
