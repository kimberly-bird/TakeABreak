using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TakeABreak.Data.Migrations
{
    public partial class UpdatedDayModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductivityRating",
                table: "Day",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductivityRating",
                table: "Day",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
