using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISMWebApp.Migrations
{
    public partial class LocationMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "locations",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "locations",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "locations",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "coursesinstitute",
                type: "money",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "money",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "name",
                table: "locations");

            migrationBuilder.AlterColumn<float>(
                name: "total",
                table: "coursesinstitute",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
