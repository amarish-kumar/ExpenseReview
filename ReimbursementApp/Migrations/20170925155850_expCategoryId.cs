using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class expCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpCategoryCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpCategoryCategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers");

            migrationBuilder.AddColumn<int>(
                name: "ExpCategoryId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ExpenseCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExpenseCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories",
                columns: new[] { "CategoryId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers",
                columns: new[] { "ApproverId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpCategoryCategoryId_ExpCategoryId",
                table: "Expenses",
                columns: new[] { "ExpCategoryCategoryId", "ExpCategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpCategoryCategoryId_ExpCategoryId",
                table: "Expenses",
                columns: new[] { "ExpCategoryCategoryId", "ExpCategoryId" },
                principalTable: "ExpenseCategories",
                principalColumns: new[] { "CategoryId", "Id" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpCategoryCategoryId_ExpCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpCategoryCategoryId_ExpCategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers");

            migrationBuilder.DropColumn(
                name: "ExpCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExpenseCategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ExpenseCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvers",
                table: "Approvers",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpCategoryCategoryId",
                table: "Expenses",
                column: "ExpCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpCategoryCategoryId",
                table: "Expenses",
                column: "ExpCategoryCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
