using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISMWebApp.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_institutes_courses_courseid",
                table: "institutes");

            migrationBuilder.DropIndex(
                name: "IX_institutes_courseid",
                table: "institutes");

            migrationBuilder.DropColumn(
                name: "courseid",
                table: "institutes");

            migrationBuilder.DropColumn(
                name: "durationweeks",
                table: "institutes");

            migrationBuilder.DropColumn(
                name: "nontution",
                table: "institutes");

            migrationBuilder.DropColumn(
                name: "total",
                table: "institutes");

            migrationBuilder.DropColumn(
                name: "tution",
                table: "institutes");

            migrationBuilder.AddColumn<string>(
                name: "institutename",
                table: "institutes",
                maxLength: 40,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "coursesinstitute",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    courseid = table.Column<int>(nullable: false),
                    durationweeks = table.Column<int>(nullable: false),
                    institutionid = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    nontution = table.Column<float>(type: "money", nullable: true),
                    total = table.Column<float>(type: "money", nullable: true),
                    tution = table.Column<float>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursesinstitute", x => x.id);
                    table.UniqueConstraint("AK_coursesinstitute_id_institutionid", x => new { x.id, x.institutionid });
                    table.ForeignKey(
                        name: "FK_coursesinstitute_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coursesinstitute_institutes_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courselocations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    courseinstituteid = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    locationid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courselocations", x => x.id);
                    table.ForeignKey(
                        name: "FK_courselocations_coursesinstitute_courseinstituteid",
                        column: x => x.courseinstituteid,
                        principalTable: "coursesinstitute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courselocations_locations_locationid",
                        column: x => x.locationid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courselocations_courseinstituteid",
                table: "courselocations",
                column: "courseinstituteid");

            migrationBuilder.CreateIndex(
                name: "IX_courselocations_locationid",
                table: "courselocations",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "IX_coursesinstitute_courseid",
                table: "coursesinstitute",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_coursesinstitute_institutionid",
                table: "coursesinstitute",
                column: "institutionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courselocations");

            migrationBuilder.DropTable(
                name: "coursesinstitute");

            migrationBuilder.DropColumn(
                name: "institutename",
                table: "institutes");

            migrationBuilder.AddColumn<int>(
                name: "courseid",
                table: "institutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "durationweeks",
                table: "institutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "nontution",
                table: "institutes",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "total",
                table: "institutes",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "tution",
                table: "institutes",
                type: "money",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_institutes_courseid",
                table: "institutes",
                column: "courseid");

            migrationBuilder.AddForeignKey(
                name: "FK_institutes_courses_courseid",
                table: "institutes",
                column: "courseid",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
