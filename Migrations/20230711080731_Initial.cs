using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniClass.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funding = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33977982-bbe3-44ed-89e4-00cad7e6f6ed"), "Commercial Law" },
                    { new Guid("4912c961-39d9-4ba1-b035-523e700280c0"), "Business Management" },
                    { new Guid("9d34ba28-9a0d-4e02-8f17-04c3c31a3d5c"), "Business Information Systems" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FullName", "Funding", "MajorId" },
                values: new object[,]
                {
                    { new Guid("5b8d9c60-e4d9-4cc5-81c6-085846d2d8a5"), new DateTime(1979, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mavluda Asalxodjaeva", 1, new Guid("4912c961-39d9-4ba1-b035-523e700280c0") },
                    { new Guid("5c5e59cb-aa76-4a24-a1d6-0ff904d0cfb9"), new DateTime(1980, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Munisa Rizaeva", 1, new Guid("4912c961-39d9-4ba1-b035-523e700280c0") },
                    { new Guid("ca2089a7-327b-44c7-9d2a-edcbe3049991"), new DateTime(1981, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sitora Tulyaganova", 2, new Guid("33977982-bbe3-44ed-89e4-00cad7e6f6ed") },
                    { new Guid("fd0907e7-8362-4397-b198-b302a53274f4"), new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), "Malika Temurova", 0, new Guid("9d34ba28-9a0d-4e02-8f17-04c3c31a3d5c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_MajorId",
                table: "Students",
                column: "MajorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
