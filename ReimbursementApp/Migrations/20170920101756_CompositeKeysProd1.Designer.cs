﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ReimbursementApp.DbContext;
using ReimbursementApp.Model;
using System;

namespace ReimbursementApp.Migrations
{
    [DbContext(typeof(ExpenseReviewDbContext))]
    [Migration("20170920101756_CompositeKeysProd1")]
    partial class CompositeKeysProd1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReimbursementApp.Model.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentPerson");

                    b.Property<string>("EmployeeId");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Approver", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("ApproverId");

                    b.Property<string>("ApprovedDate");

                    b.Property<int>("ExpenseId");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.HasKey("Id", "ApproverId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("ExpenseId")
                        .IsUnique();

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentPerson");

                    b.Property<string>("EmployeeId");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Employee", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("EmployeeId");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("AlternateNumber");

                    b.Property<string>("Country");

                    b.Property<string>("DOB");

                    b.Property<string>("Email");

                    b.Property<string>("EmergencyContactDOB");

                    b.Property<string>("EmergencyContactName");

                    b.Property<string>("EmergencyContactNumber");

                    b.Property<string>("EmergencyContactRelation");

                    b.Property<string>("EmployeeName");

                    b.Property<string>("FatherDOB");

                    b.Property<string>("FatherName");

                    b.Property<string>("Mobile");

                    b.Property<string>("MotherDOB");

                    b.Property<string>("MotherName");

                    b.Property<string>("ReportingManager");

                    b.Property<bool>("SignedUp");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id", "EmployeeId");

                    b.HasAlternateKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("EmployeesEmployeeId");

                    b.Property<int?>("EmployeesId");

                    b.Property<string>("ExpenseDate")
                        .IsRequired();

                    b.Property<string>("ExpenseDetails")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int?>("StatusId");

                    b.Property<string>("SubmitDate")
                        .IsRequired();

                    b.Property<double>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("EmployeesId", "EmployeesEmployeeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ReimbursementApp.Model.TicketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Reason");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Approver", b =>
                {
                    b.HasOne("ReimbursementApp.Model.Expense")
                        .WithOne("Approvers")
                        .HasForeignKey("ReimbursementApp.Model.Approver", "ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReimbursementApp.Model.Expense", b =>
                {
                    b.HasOne("ReimbursementApp.Model.TicketStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("ReimbursementApp.Model.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId", "EmployeesEmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
