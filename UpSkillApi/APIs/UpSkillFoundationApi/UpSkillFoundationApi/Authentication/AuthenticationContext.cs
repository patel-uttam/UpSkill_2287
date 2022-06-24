using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Authentication;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Context
{
    public class AuthenticationContext : IdentityDbContext<Users>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
