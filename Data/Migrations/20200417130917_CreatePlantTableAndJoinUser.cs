using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ColdFrame.Data.Migrations
{
    public partial class CreatePlantTableAndJoinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlantName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Vegetable = table.Column<bool>(nullable: false),
                    Fruit = table.Column<bool>(nullable: false),
                    SowFrom = table.Column<DateTime>(nullable: false),
                    SowTo = table.Column<DateTime>(nullable: false),
                    HarvestFrom = table.Column<DateTime>(nullable: false),
                    HarvestTo = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlantId",
                table: "AspNetUsers",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ApplicationUserId",
                table: "Plants",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Plants_PlantId",
                table: "AspNetUsers",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Plants_PlantId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "AspNetUsers");
        }
    }
}
