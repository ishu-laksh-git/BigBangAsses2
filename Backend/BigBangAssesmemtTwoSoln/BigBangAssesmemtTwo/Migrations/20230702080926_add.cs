using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigBangAssesmemtTwo.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    UsersUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthIssue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailId", "PasswordHash", "PasswordKey", "Role" },
                values: new object[] { 1, "admin@gmail.com", new byte[] { 18, 114, 55, 107, 252, 59, 202, 66, 43, 35, 236, 18, 135, 163, 230, 15, 142, 115, 51, 116, 193, 197, 188, 88, 156, 74, 5, 38, 157, 169, 187, 88, 67, 29, 213, 58, 95, 240, 50, 114, 75, 246, 85, 225, 224, 72, 80, 106, 28, 203, 91, 179, 10, 225, 75, 138, 124, 219, 12, 48, 242, 240, 248, 226 }, new byte[] { 18, 55, 208, 14, 189, 115, 71, 85, 210, 59, 56, 99, 252, 14, 81, 155, 93, 102, 11, 116, 234, 218, 255, 231, 20, 13, 61, 242, 31, 244, 91, 79, 224, 231, 161, 240, 115, 40, 250, 154, 223, 248, 14, 217, 126, 209, 228, 45, 70, 218, 168, 122, 225, 153, 137, 71, 161, 241, 186, 116, 221, 41, 230, 156, 185, 95, 56, 122, 109, 216, 82, 24, 159, 54, 111, 95, 42, 250, 46, 39, 169, 88, 122, 182, 144, 188, 239, 237, 231, 153, 8, 233, 39, 234, 9, 69, 10, 69, 123, 95, 72, 80, 97, 124, 247, 167, 168, 82, 133, 211, 162, 248, 239, 78, 13, 189, 114, 209, 150, 119, 54, 28, 221, 197, 110, 250, 233, 249 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UsersUserId",
                table: "Doctors",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UsersUserId",
                table: "Patients",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
