using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backpacks2",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpacks2", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Backpacks2_Characters2_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpacks2_Items2_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTitles2",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTitles2", x => new { x.CharacterId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_CharacterTitles2_Characters2_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTitles2_Titles2_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters2",
                columns: new[] { "Id", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 43, "John", "Yakuza", 200 });

            migrationBuilder.InsertData(
                table: "Items2",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Item1", 10 },
                    { 2, "Item2", 11 }
                });

            migrationBuilder.InsertData(
                table: "Titles2",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Title1" });

            migrationBuilder.InsertData(
                table: "Backpacks2",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterTitles2",
                columns: new[] { "CharacterId", "TitleId", "AcquiredAt" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 11, 11, 13, 19, 924, DateTimeKind.Local).AddTicks(4244) });

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks2_ItemId",
                table: "Backpacks2",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitles2_TitleId",
                table: "CharacterTitles2",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpacks2");

            migrationBuilder.DropTable(
                name: "CharacterTitles2");

            migrationBuilder.DropTable(
                name: "Items2");

            migrationBuilder.DropTable(
                name: "Characters2");

            migrationBuilder.DropTable(
                name: "Titles2");
        }
    }
}
