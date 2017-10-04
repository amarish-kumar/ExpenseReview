using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class ImageModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Docs",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Documentses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documentses_ExpenseId",
                table: "Documentses",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documentses_Expenses_ExpenseId",
                table: "Documentses",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentses_Expenses_ExpenseId",
                table: "Documentses");

            migrationBuilder.DropIndex(
                name: "IX_Documentses_ExpenseId",
                table: "Documentses");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Documentses");

            migrationBuilder.AddColumn<string>(
                name: "Docs",
                table: "Expenses",
                nullable: true);
        }
    }
}
