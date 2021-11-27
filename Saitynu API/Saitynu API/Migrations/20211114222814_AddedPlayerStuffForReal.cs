using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Saitynu_API.Migrations
{
    public partial class AddedPlayerStuffForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelNumber = table.Column<int>(type: "int", nullable: false),
                    CompletionTime = table.Column<float>(type: "real", nullable: false),
                    NumberOfTries = table.Column<int>(type: "int", nullable: false),
                    NumberOfSteps = table.Column<int>(type: "int", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerLevels_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLevels_PlayerId",
                table: "PlayerLevels",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerLevels");
        }
    }
}
