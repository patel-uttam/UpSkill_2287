using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpSkillFoundationApi.Models.queryParams
{
    public class EmployeeQueryParam
    {
        // jobTitle
        public List<string> JobTitle { get; set; }
        public string OrganizationLevel { get; set; }
        public string StartVacation { get; set; }
        public string EndVacation { get; set; }
        public string StartSickleave { get; set; }
        public string EndSickleave { get; set; }

        // paging 
        public int PageNumber { get; set; }
        public int ItemPerPage { get; set; }

        public EmployeeQueryParam()
        {
            ItemPerPage = 10;
            PageNumber = 1;
            JobTitle = new List<string>();
            OrganizationLevel = "";
            StartVacation = "";
            EndVacation = "";
            StartSickleave = "";
            EndSickleave = "";
        }
        public EmployeeQueryParam(int pagenumber, int itemperpage ,List<string> jobtitle , string organizationlevel , string startvacation , string endvacation , string startsickleave , string endsickleavel)
        {
            PageNumber = pagenumber < 1 ? 1 : pagenumber;
            ItemPerPage = itemperpage < 1 || itemperpage > 100 ? 10 : itemperpage;

            JobTitle = jobtitle;
            OrganizationLevel = organizationlevel;
            StartVacation = startvacation;
            EndVacation = endvacation;
            StartSickleave = startsickleave;
            EndSickleave = endsickleavel;
            
        }
    }
}
