using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class modifiedmodel8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Approvers_ApproversId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ApproversId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ApproversId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeesId",
                table: "Expenses",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvers_ExpenseId",
                table: "Approvers",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvers_Expenses_ExpenseId",
                table: "Approvers",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Approvers_Expenses_ExpenseId",
                table: "Approvers");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeesId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_EmployeesId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Approvers_ExpenseId",
                table: "Approvers");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApproversId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ApproversId",
                table: "Expenses",
                column: "ApproversId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Approvers_ApproversId",
                table: "Expenses",
                column: "ApproversId",
                principalTable: "Approvers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
