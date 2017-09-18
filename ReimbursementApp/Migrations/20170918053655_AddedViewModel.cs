using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class AddedViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Expenses_ExpenseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ExpenseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Approvers_ExpenseId",
                table: "Approvers");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Employees");

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

            migrationBuilder.DropIndex(
                name: "IX_Approvers_ExpenseId",
                table: "Approvers");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ExpenseId",
                table: "Employees",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvers_ExpenseId",
                table: "Approvers",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Expenses_ExpenseId",
                table: "Employees",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
