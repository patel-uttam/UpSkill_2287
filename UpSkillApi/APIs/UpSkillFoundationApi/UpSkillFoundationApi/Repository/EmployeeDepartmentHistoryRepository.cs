using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UpSkillFoundationApi.Repository
{
    public class EmployeeDepartmentHistoryRepository : IEmployeeDepartmentHistoryRepository
    {
        private readonly AdventureWorks2019Context context;

        public EmployeeDepartmentHistoryRepository(AdventureWorks2019Context _context)
        {
            context = _context;
        }
        public IEnumerable<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory()
        {
            List<EmployeeDepartmentHistory> EmployeeDepartmentHistory = new List<EmployeeDepartmentHistory>();
            try
            {
                IEnumerable<EmployeeDepartmentHistory> result = context.EmployeeDepartmentHistories.FromSqlRaw("SELECT * FROM HumanResources.EmployeeDepartmentHistory");
                EmployeeDepartmentHistory.AddRange(result.ToList());
            }
            catch
            {
                EmployeeDepartmentHistory = null;
            }
            return EmployeeDepartmentHistory;
        }

        /* public EmployeeDepartmentHistory GetEmployeeDepartmentHistoryByBusinessId(int BusId , int DeptId)
        {
            try
            {
                throw new NotImplementedException();

            }
            catch(Exception e)
            {
                throw e;
            }
        } */
    }
}
