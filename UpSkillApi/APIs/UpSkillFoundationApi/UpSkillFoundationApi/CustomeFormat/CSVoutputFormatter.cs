using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UpSkillFoundationApi.Models;
using Microsoft.AspNetCore.Mvc;
using UpSkillFoundationApi.Models.Response;

namespace UpSkillFoundationApi.CustomeFormat
{
    public class CSVoutputFormatter : TextOutputFormatter
    {
        public CSVoutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

        }

        protected override bool CanWriteType(Type type)
        {
            if(typeof(EmployeeResponse<List<Employee>>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            else if(typeof(Employee).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            else
            {

                Console.WriteLine( "dgfoihgoighpg9hrapaghpvhs" , type.GetType());
                Console.WriteLine("*********");
                return false;
            }
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var result = new StringBuilder();
                result.AppendLine("BusinessEntityID,NationalIDNumber,LoginID,OrganizationLevel,JobTitle,BirthDate,MaritalStatus,Gender,HireDate,SalariedFlag,VacationHours,SickLeaveHours,CurrentFlag,rowguid,ModifiedDate");
            if (context.Object is EmployeeResponse<List<Employee>>)
            {
                var outputdata = (EmployeeResponse<List<Employee>>)context.Object;
                foreach (var emp in (List<Employee>)outputdata.Data)
                {
                    ResponseFornmat(result, emp);
                }
            }
            else
            {
                ResponseFornmat(result, (Employee)context.Object);
            }


            await response.WriteAsync(result.ToString(), selectedEncoding);
        }

        public static void ResponseFornmat(StringBuilder result , Employee employee)
        {
            Console.WriteLine("primary kewy" + employee.BusinessEntityId.ToString());
            result.AppendLine(employee.BusinessEntityId.ToString()+','+employee.NationalIdnumber+','+employee.LoginId+','+employee.OrganizationLevel+','+employee.JobTitle+','+employee.BirthDate+','+employee.MaritalStatus+','+employee.Gender+','+employee.HireDate+','+employee.SalariedFlag+','+employee.VacationHours+','+employee.SickLeaveHours+','+employee.CurrentFlag+','+employee.Rowguid+','+employee.ModifiedDate);

            //result.AppendLine(employee.ToString());
        }
    }
}
