using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class UniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");
        }
    }
}
