using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstudentApplication.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentPrimaryInfo",
                columns: table => new
                {
                    Studid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: true),
                    Sname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true),
                    Mentor = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPrimaryInfo", x => x.Studid);
                });

            migrationBuilder.CreateTable(
                name: "StudentsecondaryInfo",
                columns: table => new
                {
                    Infoid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studid = table.Column<int>(nullable: false),
                    FatherName = table.Column<string>(nullable: true),
                    Fthrcontact = table.Column<string>(nullable: true),
                    Mtrname = table.Column<string>(nullable: true),
                    Mtrcontact = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsecondaryInfo", x => x.Infoid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_login",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_login", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentPrimaryInfo");

            migrationBuilder.DropTable(
                name: "StudentsecondaryInfo");

            migrationBuilder.DropTable(
                name: "tbl_login");
        }
    }
}
