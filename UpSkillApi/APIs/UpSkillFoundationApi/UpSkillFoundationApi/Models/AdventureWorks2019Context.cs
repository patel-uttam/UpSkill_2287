using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UpSkillFoundationApi.Models
{
    public partial class AdventureWorks2019Context : DbContext
    {
        public AdventureWorks2019Context()
        {
        }

        public AdventureWorks2019Context(DbContextOptions<AdventureWorks2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0453\\MSSQL2019;Database=AdventureWorks2019;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasComment("Lookup table containing the departments within the Adventure Works Cycles company.");

                entity.Property(e => e.DepartmentId).HasComment("Primary key for Department records.");

                entity.Property(e => e.GroupName).HasComment("Name of the group to which the department belongs.");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name).HasComment("Name of the department.");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PK_Employee_BusinessEntityID");

                entity.HasComment("Employee information such as salary, department, and title.");

                entity.Property(e => e.BusinessEntityId)
                    .ValueGeneratedNever()
                    .HasComment("Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID.");

                entity.Property(e => e.BirthDate).HasComment("Date of birth.");

                entity.Property(e => e.CurrentFlag)
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Inactive, 1 = Active");

                entity.Property(e => e.Gender)
                    .IsFixedLength(true)
                    .HasComment("M = Male, F = Female");

                entity.Property(e => e.HireDate).HasComment("Employee hired on this date.");

                entity.Property(e => e.JobTitle).HasComment("Work title such as Buyer or Sales Representative.");

                entity.Property(e => e.LoginId).HasComment("Network login.");

                entity.Property(e => e.MaritalStatus)
                    .IsFixedLength(true)
                    .HasComment("M = Married, S = Single");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.NationalIdnumber).HasComment("Unique national identification number such as a social security number.");

                entity.Property(e => e.OrganizationLevel)
                    .HasComputedColumnSql("([OrganizationNode].[GetLevel]())", false)
                    .HasComment("The depth of the employee in the corporate hierarchy.");

                entity.Property(e => e.Rowguid)
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.Property(e => e.SalariedFlag)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining.");

                entity.Property(e => e.SickLeaveHours).HasComment("Number of available sick leave hours.");

                entity.Property(e => e.VacationHours).HasComment("Number of available vacation hours.");
            });

            modelBuilder.Entity<EmployeeDepartmentHistory>(entity =>
            {
                entity.HasKey(e => new { e.BusinessEntityId, e.StartDate, e.DepartmentId, e.ShiftId })
                    .HasName("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID");

                entity.HasComment("Employee department transfers.");

                entity.Property(e => e.BusinessEntityId).HasComment("Employee identification number. Foreign key to Employee.BusinessEntityID.");

                entity.Property(e => e.StartDate).HasComment("Date the employee started work in the department.");

                entity.Property(e => e.DepartmentId).HasComment("Department in which the employee worked including currently. Foreign key to Department.DepartmentID.");

                entity.Property(e => e.ShiftId).HasComment("Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.");

                entity.Property(e => e.EndDate).HasComment("Date the employee left the department. NULL = Current department.");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.HasOne(d => d.BusinessEntity)
                    .WithMany(p => p.EmployeeDepartmentHistories)
                    .HasForeignKey(d => d.BusinessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDepartmentHistories)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeDepartmentHistories)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasComment("Work shift lookup table.");

                entity.Property(e => e.ShiftId)
                    .ValueGeneratedOnAdd()
                    .HasComment("Primary key for Shift records.");

                entity.Property(e => e.EndTime).HasComment("Shift end time.");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name).HasComment("Shift description.");

                entity.Property(e => e.StartTime).HasComment("Shift start time.");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
