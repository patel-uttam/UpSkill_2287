using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace UpSkillFoundationApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AdventureWorks2019Context context;

        public EmployeeRepository(AdventureWorks2019Context _context)
        {
            context = _context;
        }

        public Employee GetEmployee(int EmployeeId)
        {
            try
            {
                return context.Employees.FirstOrDefault(e => e.BusinessEntityId == EmployeeId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetFilterEmployees(List<string> jobname, string organization, string vacationHless, string vacationHgreater, string sicknessHless, string sicknessHgreater)
        {
            List<Employee> FinalresultedEmployee = new List<Employee>();

            try
            {
                if (jobname.Count() <= 0)
                {
                    IEnumerable<Employee> resultedEmployee = context.Employees.FromSqlRaw("EmployeeFilter {0},{1}", null,organization );
                    FinalresultedEmployee.AddRange(resultedEmployee.ToList());
                }
                else
                {
                    foreach (var jt in jobname)
                    {
                        IEnumerable<Employee> resultedEmployee = context.Employees.FromSqlRaw("EmployeeFilter {0},{1}", jt, organization);
                        FinalresultedEmployee.AddRange(resultedEmployee.ToList());
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return FinalresultedEmployee;
        }

        public IEnumerable<string> GetDistinctjobTitle()
        {
            try
            {
                return context.Employees.Select(e => e.JobTitle).Distinct();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<short?> GetDistinctOrganizationLevel()
        {
            try
            {
                return context.Employees.Select(e => e.OrganizationLevel).Distinct();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetEmpDeptHistory(int Deptid)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                IEnumerable<Employee> resultedemployees = context.Employees.FromSqlRaw(" exec dbo.EmployeeByDepartment {0}", Deptid);
                employees.AddRange(resultedemployees.ToList());
            }
            catch(Exception e)
            {
                throw e;
            }
            return employees;
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                context.Update(employee);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
