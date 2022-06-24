using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillFoundationApi.Models;

namespace UpSkillFoundationApi.Repository
{
    public interface IEmployeeDepartmentHistoryRepository
    {
        public IEnumerable<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory();
        //public EmployeeDepartmentHistory GetEmployeeDepartmentHistoryByBusinessId(int BusId, int DeptId);
    }
}
