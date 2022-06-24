using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Repository
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetDepartments();

    }
}
