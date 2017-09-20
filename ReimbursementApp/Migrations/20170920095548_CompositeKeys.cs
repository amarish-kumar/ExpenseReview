using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class CompositeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeesEmployeeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_EmployeesEmployeeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Approvers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                columns: new[] { "Id", "EmployeeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers",
                columns: new[] { "Id", "ApproverId" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeesId_EmployeesEmployeeId",
                table: "Expenses",
                columns: new[] { "EmployeesId", "EmployeesEmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeesId_EmployeesEmployeeId",
                table: "Expenses",
                columns: new[] { "EmployeesId", "EmployeesEmployeeId" },
                principalTable: "Employees",
                principalColumns: new[] { "Id", "EmployeeId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeesId_EmployeesEmployeeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_EmployeesId_EmployeesEmployeeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "Approvers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeesEmployeeId",
                table: "Expenses",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeesEmployeeId",
                table: "Expenses",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
