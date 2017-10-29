using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class ApproverModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApproverLists",
                table: "ApproverLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApproverLists",
                table: "ApproverLists",
                columns: new[] { "ApproverId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_ApproverLists_ApproverId",
                table: "ApproverLists",
                column: "ApproverId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApproverLists",
                table: "ApproverLists");

            migrationBuilder.DropIndex(
                name: "IX_ApproverLists_ApproverId",
                table: "ApproverLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApproverLists",
                table: "ApproverLists",
                column: "Id");
        }
    }
}
