using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UpSkillFoundationApi.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AdventureWorks2019Context context;

        public DepartmentRepository(AdventureWorks2019Context _context)
        {
            context = _context;
        }
        public IEnumerable<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                IEnumerable<Department> resulteddepartments = context.Departments.ToList();

                departments.AddRange(resulteddepartments.ToList());
            }
            catch
            {
                departments = null;
            }

            return departments;
        }

    }
}
