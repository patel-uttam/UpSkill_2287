using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Repository
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public IEnumerable<Employee> GetFilterEmployees(List<string> jobname , string organization , string vacationHless , string vacationHgreater);
        public Employee GetEmployee(int EmployeeId);
        public IEnumerable<string> GetDistinctjobTitle();
        public IEnumerable<short?> GetDistinctOrganizationLevel();

        public IEnumerable<Employee> GetEmpDeptHistory(int Deptid);

        public bool UpdateEmployee(Employee employee);
    }
}
