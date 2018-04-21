using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FKTeplice.Data.Migrations
{
    public partial class CreatePositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AltPositionId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AltPositionId",
                table: "Players",
                column: "AltPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_AltPositionId",
                table: "Players",
                column: "AltPositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_AltPositionId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Players_AltPositionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PositionId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AltPositionId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Players");
        }
    }
}
