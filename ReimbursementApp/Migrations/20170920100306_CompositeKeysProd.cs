﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReimbursementApp.Migrations
{
    public partial class CompositeKeysProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_Id",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Approvers_Id",
                table: "Approvers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_Id",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Approvers_Id",
                table: "Approvers");
        }
    }
}
