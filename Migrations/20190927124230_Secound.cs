using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportCVS.Migrations
{
    public partial class Secound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CSVModel",
                table: "CSVModel");

            migrationBuilder.RenameTable(
                name: "CSVModel",
                newName: "CSV");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CSV",
                table: "CSV",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LOG",
                columns: table => new
                {
                    logId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG", x => x.logId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CSV",
                table: "CSV");

            migrationBuilder.RenameTable(
                name: "CSV",
                newName: "CSVModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CSVModel",
                table: "CSVModel",
                column: "Id");
        }
    }
}
