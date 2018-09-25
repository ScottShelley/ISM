using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISMWebApp.Migrations
{
    public partial class AddImageKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "key",
                table: "image",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "imgurl",
                table: "courses",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "key",
                table: "image");

            migrationBuilder.AlterColumn<string>(
                name: "imgurl",
                table: "courses",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
