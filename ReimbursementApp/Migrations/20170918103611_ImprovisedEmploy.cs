using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class ImprovisedEmploy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Approvers_ReportingManagerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ReportingManagerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportingManagerId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ReportingManager",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportingManager",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ReportingManagerId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportingManagerId",
                table: "Employees",
                column: "ReportingManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Approvers_ReportingManagerId",
                table: "Employees",
                column: "ReportingManagerId",
                principalTable: "Approvers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
