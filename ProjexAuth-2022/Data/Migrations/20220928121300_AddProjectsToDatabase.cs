using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjexAuth_2022.Data.Migrations
{
    public partial class AddProjectsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
