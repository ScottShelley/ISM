using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISMWebApp.Migrations
{
    public partial class CourseLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coursestructure",
                table: "courses");

            migrationBuilder.AlterColumn<string>(
                name: "postcode",
                table: "locations",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "courses",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level",
                table: "courses");

            migrationBuilder.AlterColumn<int>(
                name: "postcode",
                table: "locations",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "coursestructure",
                table: "courses",
                nullable: true);
        }
    }
}
