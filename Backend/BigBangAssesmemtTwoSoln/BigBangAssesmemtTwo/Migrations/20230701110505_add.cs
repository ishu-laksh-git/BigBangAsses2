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
                values: new object[] { 1, "admin@gmail.com", new byte[] { 26, 179, 69, 149, 225, 141, 59, 11, 222, 150, 45, 46, 192, 17, 89, 146, 12, 233, 51, 57, 98, 247, 70, 119, 152, 190, 183, 19, 195, 68, 173, 55, 159, 245, 45, 242, 209, 68, 240, 147, 98, 15, 91, 19, 65, 221, 217, 94, 46, 234, 94, 40, 150, 76, 158, 18, 193, 80, 68, 97, 120, 105, 110, 35 }, new byte[] { 151, 28, 11, 30, 101, 155, 222, 184, 235, 126, 184, 216, 59, 63, 219, 120, 81, 173, 5, 203, 5, 120, 173, 218, 40, 219, 20, 17, 204, 148, 202, 198, 151, 248, 41, 209, 138, 200, 99, 108, 126, 167, 86, 177, 130, 202, 107, 108, 15, 59, 185, 70, 54, 156, 15, 100, 77, 189, 135, 217, 194, 18, 141, 210, 95, 103, 127, 40, 184, 117, 66, 255, 228, 111, 183, 111, 203, 77, 203, 205, 9, 81, 168, 42, 13, 50, 119, 48, 18, 64, 109, 53, 192, 132, 229, 57, 12, 27, 53, 193, 144, 164, 164, 226, 195, 228, 84, 61, 179, 81, 168, 106, 25, 224, 135, 108, 142, 205, 121, 164, 225, 38, 49, 159, 232, 251, 211, 11 }, "Admin" });

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
