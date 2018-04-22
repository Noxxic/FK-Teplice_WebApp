using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FKTeplice.Data.Migrations
{
    public partial class CreatePlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ContractFrom = table.Column<DateTime>(nullable: false),
                    ContractTo = table.Column<DateTime>(nullable: false),
                    Fat = table.Column<double>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
