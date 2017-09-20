using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class CompositeKeysProd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "EmployeesEmployeeId",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Approvers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeesId",
                table: "Expenses",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeesId",
                table: "Expenses",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeesId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_EmployeesId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers");

            migrationBuilder.AddColumn<string>(
                name: "EmployeesEmployeeId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Approvers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
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
    }
}
