using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UpSkillFoundationApi.Models
{
    [Table("Employee", Schema = "HumanResources")]
    [Index(nameof(LoginId), Name = "AK_Employee_LoginID", IsUnique = true)]
    [Index(nameof(NationalIdnumber), Name = "AK_Employee_NationalIDNumber", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_Employee_rowguid", IsUnique = true)]
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [Column("NationalIDNumber")]
        [StringLength(15)]
        public string NationalIdnumber { get; set; }
        [Required]
        [Column("LoginID")]
        [StringLength(256)]
        public string LoginId { get; set; }
        public short? OrganizationLevel { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(1)]
        public string MaritalStatus { get; set; }
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }
        [Required]
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        [Required]
        public bool? CurrentFlag { get; set; }
        //[Required]
        [Column("rowguid")]
        [RegularExpression(@"^[A-Za-z0-9-']{10,40}$" , ErrorMessage ="input not valid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(EmployeeDepartmentHistory.BusinessEntity))]
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}
