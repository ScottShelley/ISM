using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ISMWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    careers = table.Column<string>(nullable: true),
                    code = table.Column<string>(maxLength: 10, nullable: false),
                    coursestructure = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: false),
                    entryrequirements = table.Column<string>(nullable: true),
                    imgurl = table.Column<string>(maxLength: 50, nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    overview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visascategory",
                columns: table => new
                {
                    visaurl = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    imgurl = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visascategory", x => x.visaurl);
                });

            migrationBuilder.CreateTable(
                name: "institutes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    courseid = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    durationweeks = table.Column<int>(nullable: false),
                    imgurl = table.Column<string>(maxLength: 50, nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    nontution = table.Column<float>(type: "money", nullable: true),
                    provider = table.Column<string>(maxLength: 40, nullable: false),
                    total = table.Column<float>(type: "money", nullable: true),
                    tution = table.Column<float>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutes", x => x.id);
                    table.ForeignKey(
                        name: "FK_institutes_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visaspage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    url = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    imgurl = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visaspage", x => new { x.id, x.url });
                    table.UniqueConstraint("AK_visaspage_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_visaspage_visascategory_url",
                        column: x => x.url,
                        principalTable: "visascategory",
                        principalColumn: "visaurl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    country = table.Column<string>(maxLength: 30, nullable: false),
                    instituteid = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    postcode = table.Column<int>(nullable: false),
                    state = table.Column<string>(maxLength: 30, nullable: false),
                    street = table.Column<string>(maxLength: 50, nullable: false),
                    suburb = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_locations_institutes_instituteid",
                        column: x => x.instituteid,
                        principalTable: "institutes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    html = table.Column<string>(nullable: false),
                    imgurl = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    visaspageid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visas", x => x.id);
                    table.ForeignKey(
                        name: "FK_visas_visaspage_visaspageid",
                        column: x => x.visaspageid,
                        principalTable: "visaspage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_institutes_courseid",
                table: "institutes",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_locations_instituteid",
                table: "locations",
                column: "instituteid");

            migrationBuilder.CreateIndex(
                name: "IX_visas_visaspageid",
                table: "visas",
                column: "visaspageid");

            migrationBuilder.CreateIndex(
                name: "IX_visaspage_url",
                table: "visaspage",
                column: "url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "visas");

            migrationBuilder.DropTable(
                name: "institutes");

            migrationBuilder.DropTable(
                name: "visaspage");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "visascategory");
        }
    }
}
