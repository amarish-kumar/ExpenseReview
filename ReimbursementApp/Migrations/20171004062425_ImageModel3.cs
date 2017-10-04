using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class ImageModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documentses_ExpenseId",
                table: "Documentses");

            migrationBuilder.CreateIndex(
                name: "IX_Documentses_ExpenseId",
                table: "Documentses",
                column: "ExpenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documentses_ExpenseId",
                table: "Documentses");

            migrationBuilder.CreateIndex(
                name: "IX_Documentses_ExpenseId",
                table: "Documentses",
                column: "ExpenseId",
                unique: true);
        }
    }
}
