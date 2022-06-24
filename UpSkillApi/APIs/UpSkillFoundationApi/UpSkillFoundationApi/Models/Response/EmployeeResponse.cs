using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpSkillFoundationApi.Models.Response
{
    public class EmployeeResponse<T>
    {
        public T Data { get; set; }
        public int? PageNumber { get; set; }
        public int? ItemPerPage { get; set; }
        public int? TotalItem { get; set; }
        public bool isprevious { get; set; }
        public bool isnext { get; set; }
        public IList<string> jobTitle { get; set; }
        public IList<short?> organizationLevel { get; set; }
        public EmployeeResponse(T data , int? pagenumber , int? itemperpage , bool previous , bool next , IList<string> JobTitle , IList<short?> OrganizationLevel)
        {
            this.Data = data;
            this.PageNumber = pagenumber;
            this.ItemPerPage = itemperpage;
            this.isprevious = previous;
            this.isnext = next;
            jobTitle = JobTitle;
            organizationLevel = OrganizationLevel;
        }
    }
}
