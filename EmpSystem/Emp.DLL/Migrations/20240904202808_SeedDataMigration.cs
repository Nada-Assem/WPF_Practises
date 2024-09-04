using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Emp.DLL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deparments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "IT" },
                    { 3, "Finance" },
                    { 4, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DepartmentId", "HireDate", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", 50000m },
                    { 2, 2, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", 60000m },
                    { 3, 2, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", 55000m },
                    { 4, 3, new DateTime(2018, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark Thompson", 70000m },
                    { 5, 3, new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily Brown", 48000m },
                    { 6, 4, new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Wilson", 62000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Deparments");
        }
    }
}
